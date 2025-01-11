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
using ProLab.Domain.Orders;
using ProLab.Domain.Routes;
using ProLab.Domain.Warehouses;

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
        IEnumerable<Warehouse> warehouses = await _db.Warehouses
            .Include(warehouse => warehouse.Orders)
            .ToArrayAsync(cancellationToken);

        int totalCouriersNeeded = 0;
        DateOnly currentDate = command.Date;
        var results = new Dictionary<int, List<RouteAssignment>>();

        foreach (Warehouse warehouse in warehouses)
        {
            var unassignedOrders = warehouse.Orders.ToList();

            int courierIndex = 1;
            var warehouseResults = new List<RouteAssignment>();

            while (unassignedOrders.Count != 0)
            {
                var assignedOrders = new List<Order>();
                double totalDistance = 0;
                double totalTime = 0;
                Point currentCoordinate = warehouse.Address.Location;

                while (unassignedOrders.Count != 0)
                {
                    Order? nearestOrder = null;
                    Result<OpenRouteDirectionsResult> routeResult;
                    OpenRouteDirectionsResult route;

                    foreach (Order order in unassignedOrders)
                    {
                        routeResult = await _openRouteService.GetDirectionsAsync(currentCoordinate, order.Address.Location, cancellationToken);

                        if (routeResult.IsSuccess)
                        {
                            route = routeResult.Value;

                            //DateTime arrivalDate = currentDate.AddSeconds(route.Duration);

                            //if (arrivalDate >= order.StartTime && arrivalDate <= order.EndTime && route.Distance < minDistance)
                            //{
                            //    minDistance = route.Distance;
                            //    nearestOrder = order;
                            //}
                        }
                    }

                    if (nearestOrder == null)
                        break;

                    routeResult = await _openRouteService.GetDirectionsAsync(currentCoordinate, nearestOrder.Address.Location, cancellationToken);

                    if (routeResult.IsFailed)
                        break;

                    route = routeResult.Value;

                    //currentDate = currentDate.AddSeconds(route.Duration);
                    totalDistance += route.Distance;
                    totalTime += route.Duration;

                    assignedOrders.Add(nearestOrder);
                    currentCoordinate = nearestOrder.Address.Location;
                    _ = unassignedOrders.Remove(nearestOrder);
                }

                warehouseResults.Add(
                    new RouteAssignment
                    {
                        AssignedOrders = assignedOrders,
                        TotalDistance = totalDistance,
                        TotalTime = totalTime
                    });

                courierIndex++;
            }

            totalCouriersNeeded += courierIndex - 1;
            results[warehouse.Id] = warehouseResults;
        }

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

    class RouteAssignment
    {
        public IEnumerable<Order> AssignedOrders { get; set; }
        public double TotalDistance { get; set; }
        public double TotalTime { get; set; }
    }
}
