using ProLab.Api.Common;
using ProLab.Application.Common.Query;
using ProLab.Application.Warehouses.Commands;
using ProLab.Application.Warehouses.Query;
using ProLab.Application.Warehouses.Results;
using ProLab.Domain.Warehouses;
using ProLab.Shared.Warehouses.Requests;
using ProLab.Shared.Warehouses.Response;

namespace ProLab.Api.Features.Warehouses;

internal static class WarehouseMappingExtensions
{
    public static CreateWarehouseCommand ToCommand(this CreateWarehouseRequest request)
    {
        return new CreateWarehouseCommand
        {
            Name = request.Name,
            Address = request.Address.ToData()
        };
    }

    public static UpdateWarehouseCommand ToCommand(this UpdateWarehouseRequest request)
    {
        return new UpdateWarehouseCommand
        {
            Name = request.Name,
            Address = request.Address.ToData()
        };
    }

    public static QueryParameters<Warehouse> ToQueryParameters(this GetWarehouseListRequest request)
    {
        return new QueryParameters<Warehouse>
        {
            Filter = request.Filter == null ? null : new WarehouseFilter
            {
                Search = request.Filter.Search
            },
            Sorting = request.Sorting == null ? null : new WarehouseSorting
            {
                IsDescending = request.Sorting.IsDescending,
                Sort = request.Sorting.Sort
            },
            Paging = request.Paging?.ToParameters()
        };
    }

    public static GetWarehouseResponse ToResponse(this WarehouseResult result)
    {
        return new GetWarehouseResponse
        {
            Id = result.Id,
            Name = result.Name,
            Address = result.Address.ToData()
        };
    }

    public static GetWarehouseListResponse ToResponse(this WarehouseListResult result)
    {
        return new GetWarehouseListResponse
        {
            Items = result.Items.Select(item => new GetWarehouseListResponse.ItemData
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address.ToData()
            }),
            TotalCount = result.TotalCount,
            PageSize = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }
}
