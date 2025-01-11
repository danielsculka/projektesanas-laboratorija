using ProLab.Application.Addresses;
using ProLab.Application.Orders.Commands;
using ProLab.Application.Orders.Results;
using ProLab.Domain.Addresses;
using ProLab.Domain.Orders;
using System.Linq.Expressions;

namespace ProLab.Application.Orders;

internal static class OrderMapper
{
    public static Order ToEntity(this CreateOrderCommand command, Order entity)
    {
        entity.Number = command.Number;
        entity.StartTime = command.StartTime;
        entity.EndTime = command.EndTime;
        entity.WarehouseId = command.WarehouseId;

        entity.Address = command.Address.ToEntity(new Address());

        return entity;
    }

    public static Order ToEntity(this UpdateOrderCommand command, Order entity)
    {
        entity.Number = command.Number;
        entity.StartTime = command.StartTime;
        entity.EndTime = command.EndTime;
        entity.WarehouseId = command.WarehouseId;

        _ = command.Address.ToEntity(entity.Address);

        return entity;
    }

    public static Expression<Func<Order, OrderResult>> Project()
    {
        return order => new OrderResult
        {
            Id = order.Id,
            Number = order.Number,
            Address = order.Address.FromEntity(),
            StartTime = order.StartTime,
            EndTime = order.EndTime,
            WarehouseId = order.WarehouseId
        };
    }

    public static Expression<Func<Order, OrderListResult.ItemData>> ProjectList()
    {
        return order => new OrderListResult.ItemData
        {
            Id = order.Id,
            Number = order.Number,
            Address = order.Address.FromEntity(),
            StartTime = order.StartTime,
            EndTime = order.EndTime,
            Warehouse = new OrderListResult.ItemData.WarehouseData
            {
                Id = order.Warehouse.Id,
                Name = order.Warehouse.Name
            }
        };
    }
}
