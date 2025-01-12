using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;
using ProLab.Application.Common.Query;
using ProLab.Application.Extensions;
using ProLab.Application.OpenRoute;
using ProLab.Application.OpenRoute.Results;
using ProLab.Application.RouteSets.Commands;
using ProLab.Application.RouteSets.Results;
using ProLab.Domain.Couriers;
using ProLab.Domain.Orders;
using ProLab.Domain.Routes;
using ProLab.Domain.Warehouses;
using System.Diagnostics;

namespace ProLab.Application.RouteSets;

public class RouteSetService : IRouteSetService
{
    private readonly IAppDbContext _db;
    private readonly IOpenRouteService _openRouteService;
    private readonly ILogger<RouteSetService> _logger;

    public RouteSetService(IAppDbContext db, IOpenRouteService openRouteService, ILogger<RouteSetService> logger)
    {
        _db = db;
        _openRouteService = openRouteService;
        _logger = logger;
    }

    public async Task<Result> GenerateAsync(GenerateRouteSetCommand command, CancellationToken cancellationToken)
    {
        var stopwatch = new Stopwatch();

        int timesCalledOpenRoute = 0;

        stopwatch.Start();

        RouteSet entity = command.ToEntity(new RouteSet());

        Warehouse[] warehouses = await _db.Warehouses
            .Include(warehouse => warehouse.Orders
                .Where(order => order.Date == command.Date))
            .ToArrayAsync(cancellationToken);

        Courier[] couriers = await _db.Couriers
            .Where(courier => courier.IsActive)
            .ToArrayAsync(cancellationToken);

        foreach (Warehouse warehouse in warehouses)
        {
            List<Order> unassignedOrders = warehouse.Orders.ToList();

            while (unassignedOrders.Count > 0 && couriers.Length > entity.Routes.Count)
            {
                var route = new Route
                {
                    Courier = couriers[entity.Routes.Count]
                };

                Result<OpenRouteDirectionsResult> routeResult;
                Result<OpenRouteDirectionsResult>? routeBackResult = null;
                Point fromLocation;
                TimeOnly currentTime = command.StartTime;

                while (unassignedOrders.Count > 0)
                {
                    fromLocation = route.Sections.Count != 0
                        ? route.Sections.Last().Order.Address.Location
                        : warehouse.Address.Location;

                    Order? bestOrder = null;
                    TimeOnly arrivalTime = currentTime;
                    OpenRouteDirectionsResult? bestRoute = null;

                    foreach (Order order in unassignedOrders.Where(order => currentTime < order.EndTime))
                    {
                        routeResult = await _openRouteService.GetDirectionsAsync(
                            fromLocation,
                            order.Address.Location,
                            cancellationToken);

                        routeBackResult = await _openRouteService.GetDirectionsAsync(
                            order.Address.Location,
                            warehouse.Address.Location,
                            cancellationToken);

                        timesCalledOpenRoute += 2;

                        if (!routeResult.IsSuccess || !routeBackResult.IsSuccess)
                            continue;

                        arrivalTime = currentTime
                            .AddMinutes(routeResult.Value.Duration / 60);

                        if (arrivalTime > order.EndTime)
                            continue;

                        arrivalTime = arrivalTime > order.StartTime
                            ? arrivalTime
                            : order.StartTime;

                        if (arrivalTime.AddMinutes(routeBackResult.Value.Duration / 60) > command.EndTime)
                            continue;

                        if (bestRoute == null)
                        {
                            bestRoute = routeResult.Value;
                            bestOrder = order;
                        }
                        else if (routeResult.Value.Distance < bestRoute.Distance)
                        {
                            bestRoute = routeResult.Value;
                            bestOrder = order;
                        }
                    }

                    if (bestOrder != null && bestRoute != null)
                    {
                        _ = unassignedOrders.Remove(bestOrder);

                        arrivalTime = currentTime
                            .AddMinutes(bestRoute.Duration / 60);

                        arrivalTime = arrivalTime > bestOrder.StartTime
                            ? arrivalTime
                            : bestOrder.StartTime;

                        route.Sections.Add(new RouteSection
                        {
                            Order = bestOrder,
                            ArrivalTime = arrivalTime,
                            Distance = bestRoute.Distance,
                            Duration = bestRoute.Duration,
                            Path = bestRoute.Path
                        });

                        currentTime = arrivalTime;
                    }
                    else
                    {
                        break;
                    }
                }

                if (route.Sections.Count == 0 || (routeBackResult != null && !routeBackResult.IsSuccess))
                    break;

                route.Sections.Add(new RouteSection
                {
                    ArrivalTime = route.Sections.Last().ArrivalTime.AddMinutes(routeBackResult!.Value.Duration / 60),
                    Distance = routeBackResult.Value.Distance,
                    Duration = routeBackResult.Value.Duration,
                    Path = routeBackResult.Value.Path
                });

                entity.Routes.Add(route);
            }
        }

        stopwatch.Stop();

        entity.GenerateDuration = stopwatch.Elapsed - TimeSpan.FromMilliseconds(timesCalledOpenRoute * 1500);

        _ = _db.RouteSets.Add(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }

    public async Task<Result<RouteSetListResult>> GetAsync(QueryParameters<RouteSet> parameters, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Retrieving route sets.");

        IQueryable<RouteSet> query = _db.RouteSets
            .AsNoTracking()
            .ApplyFilter(parameters.Filter);

        int totalCount = await query.CountAsync(cancellationToken);

        RouteSetListResult.ItemData[] items = await query
            .ApplySorting(parameters.Sorting)
            .ApplyPaging(parameters.Paging)
            .Select(RouteSetMapper.ProjectList())
            .ToArrayAsync(cancellationToken);

        _logger.LogInformation("Retrieved {count} route sets.", items.Length);

        return new RouteSetListResult(
            items,
            totalCount,
            parameters.Paging?.PageSize,
            parameters.Paging?.CurrentPage
            );
    }
}
