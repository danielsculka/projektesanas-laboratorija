using ProLab.Api.Common;
using ProLab.Application.Common.Query;
using ProLab.Application.RouteSets.Commands;
using ProLab.Application.RouteSets.Query;
using ProLab.Application.RouteSets.Results;
using ProLab.Domain.Routes;
using ProLab.Shared.Common;
using ProLab.Shared.RouteSets.Requests;
using ProLab.Shared.RouteSets.Response;

namespace ProLab.Api.Features.RouteSets;

internal static class RouteSetMappingExtensions
{
    public static GenerateRouteSetCommand ToCommand(this GenerateRouteSetRequest request)
    {
        return new GenerateRouteSetCommand
        {
            Name = request.Name,
            Date = request.Date,
            StartTime = request.StartTime,
            EndTime = request.EndTime
        };
    }

    public static QueryParameters<RouteSet> ToQueryParameters(this GetRouteSetListRequest request)
    {
        return new QueryParameters<RouteSet>
        {
            Filter = request.Filter == null ? null : new RouteSetFilter
            {
                Date = request.Filter.Date
            },
            Sorting = request.Sorting == null ? null : new RouteSetSorting
            {
                IsDescending = request.Sorting.IsDescending,
                Sort = request.Sorting.Sort
            },
            Paging = request.Paging?.ToParameters()
        };
    }

    public static GetRouteSetListResponse ToResponse(this RouteSetListResult result)
    {
        return new GetRouteSetListResponse
        {
            Items = result.Items.Select(item => new GetRouteSetListResponse.ItemData
            {
                Id = item.Id,
                Name = item.Name,
                Date = item.Date,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                GenerateDuration = item.GenerateDuration,
                Routes = item.Routes.Select(route => new GetRouteSetListResponse.ItemData.RouteData
                {
                    Id = route.Id,
                    CourierId = route.CourierId,
                    Sections = route.Sections.Select(section => new GetRouteSetListResponse.ItemData.RouteData.SectionData
                    {
                        Id = section.Id,
                        OrderId = section.Id,
                        ArrivalTime = section.ArrivalTime,
                        Distance = section.Distance,
                        Duration = section.Duration,
                        Path = section.Path.Coordinates.Select(coordinate => new CoordinateData
                        {
                            Longitude = coordinate.X,
                            Latitude = coordinate.Y
                        })
                    })
                })
            }),
            TotalCount = result.TotalCount,
            PageSize = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }
}
