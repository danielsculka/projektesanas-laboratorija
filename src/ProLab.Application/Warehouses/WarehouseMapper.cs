using ProLab.Application.Addresses;
using ProLab.Application.Warehouses.Commands;
using ProLab.Application.Warehouses.Results;
using ProLab.Domain.Warehouses;
using System.Linq.Expressions;

namespace ProLab.Application.Warehouses;

internal static class WarehouseMapper
{
    public static Warehouse ToEntity(this CreateWarehouseCommand command, Warehouse entity)
    {
        entity.Name = command.Name;

        _ = command.Address.ToEntity(entity.Address);

        return entity;
    }

    public static Warehouse ToEntity(this UpdateWarehouseCommand command, Warehouse entity)
    {
        entity.Name = command.Name;

        _ = command.Address.ToEntity(entity.Address);

        return entity;
    }

    public static Expression<Func<Warehouse, WarehouseResult>> Project()
    {
        return warehouse => new WarehouseResult
        {
            Id = warehouse.Id,
            Name = warehouse.Name,
            Address = warehouse.Address.FromEntity()
        };
    }

    public static Expression<Func<Warehouse, WarehouseListResult.ItemData>> ProjectList()
    {
        return warehouse => new WarehouseListResult.ItemData
        {
            Id = warehouse.Id,
            Name = warehouse.Name,
            Address = warehouse.Address.FromEntity()
        };
    }
}
