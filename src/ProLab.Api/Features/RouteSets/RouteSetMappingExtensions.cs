using ProLab.Api.Common;
using ProLab.Application.Common.Query;
using ProLab.Application.RouteSets.Commands;
using ProLab.Application.RouteSets.Query;
using ProLab.Application.RouteSets.Results;
using ProLab.Domain.Routes;
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
                EndTime = item.EndTime
            }),
            TotalCount = result.TotalCount,
            PageSize = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }
}
