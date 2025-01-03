using ProLab.Api.Common;
using ProLab.Application.Common.Query;
using ProLab.Application.Couriers.Commands;
using ProLab.Application.Couriers.Query;
using ProLab.Application.Couriers.Results;
using ProLab.Domain.Couriers;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;

namespace ProLab.Api.Features.Couriers;

internal static class CourierMappingExtensions
{
    public static CreateCourierCommand ToCommand(this CreateCourierRequest request)
    {
        return new CreateCourierCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
        };
    }

    public static UpdateCourierCommand ToCommand(this UpdateCourierRequest request)
    {
        return new UpdateCourierCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
        };
    }

    public static QueryParameters<Courier> ToQueryParameters(this GetCourierListRequest request)
    {
        return new QueryParameters<Courier>
        {
            Filter = request.Filter == null ? null : new CourierFilter
            {
                Search = request.Filter.Search
            },
            Sorting = request.Sorting == null ? null : new CourierSorting
            {
                IsDescending = request.Sorting.IsDescending,
                Sort = request.Sorting.Sort
            },
            Paging = request.Paging?.ToParameters()
        };
    }

    public static GetCourierResponse ToResponse(this CourierResult result)
    {
        return new GetCourierResponse
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName
        };
    }

    public static GetCourierListResponse ToResponse(this CourierListResult result)
    {
        return new GetCourierListResponse
        {
            Items = result.Items.Select(item => new GetCourierListResponse.ItemData
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName
            }),
            TotalCount = result.TotalCount,
            PageSize = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }
}
