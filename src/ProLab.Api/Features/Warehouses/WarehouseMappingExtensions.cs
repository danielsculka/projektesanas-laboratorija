using ProLab.Api.Features.Warehouses.Create;
using ProLab.Api.Features.Warehouses.GetList;
using ProLab.Api.Features.Warehouses.Update;
using ProLab.Application.Common.Query;
using ProLab.Application.Warehouses.Commands;
using ProLab.Domain.Warehouses;

namespace ProLab.Api.Features.Warehouses;

internal static class WarehouseMappingExtensions
{
    public static CreateWarehouseCommand ToCommand(this CreateWarehouseRequest request)
    {
        return new CreateWarehouseCommand
        {
            Name = request.Name,
            Address = request.Address
        };
    }

    public static UpdateWarehouseCommand ToCommand(this UpdateWarehouseRequest request)
    {
        return new UpdateWarehouseCommand
        {
            Name = request.Name,
            Address = request.Address
        };
    }

    public static QueryParameters<Warehouse> ToQueryParameters(this GetWarehouseListRequest request)
    {
        return new QueryParameters<Warehouse>
        {
            Filter = request.Filter,
            Sorting = request.Sorting,
            Paging = request.Paging
        };
    }
}
