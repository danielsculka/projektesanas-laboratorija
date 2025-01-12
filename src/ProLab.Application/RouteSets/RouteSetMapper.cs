using ProLab.Application.RouteSets.Commands;
using ProLab.Application.RouteSets.Results;
using ProLab.Domain.Routes;
using System.Linq.Expressions;

namespace ProLab.Application.RouteSets;

internal static class RouteSetMapper
{
    public static RouteSet ToEntity(this GenerateRouteSetCommand command, RouteSet entity)
    {
        entity.Name = command.Name;
        entity.Date = command.Date;
        entity.StartTime = command.StartTime;
        entity.EndTime = command.EndTime;

        return entity;
    }

    public static Expression<Func<RouteSet, RouteSetListResult.ItemData>> ProjectList()
    {
        return routeSet => new RouteSetListResult.ItemData
        {
            Id = routeSet.Id,
            Name = routeSet.Name,
            Date = routeSet.Date,
            StartTime = routeSet.StartTime,
            EndTime = routeSet.EndTime,
            GenerateDuration = routeSet.GenerateDuration,
            Routes = routeSet.Routes.Select(route => new RouteSetListResult.ItemData.RouteData
            {
                Id = route.Id,
                CourierId = route.CourierId,
                Sections = route.Sections.Select(section => new RouteSetListResult.ItemData.RouteData.SectionData
                {
                    Id = section.Id,
                    OrderId = section.OrderId,
                    ArrivalTime = section.ArrivalTime,
                    Distance = section.Distance,
                    Duration = section.Duration,
                    Path = section.Path
                })
            })
        };
    }
}
