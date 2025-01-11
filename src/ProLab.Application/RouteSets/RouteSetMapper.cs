using ProLab.Application.RouteSets.Results;
using ProLab.Domain.Routes;
using System.Linq.Expressions;

namespace ProLab.Application.RouteSets;

internal static class RouteSetMapper
{
    //public static Order ToEntity(this CreateOrderCommand command, Order entity)
    //{
    //    entity.Number = command.Number;
    //    entity.Date = command.Date;
    //    entity.StartTime = command.StartTime;
    //    entity.EndTime = command.EndTime;
    //    entity.WarehouseId = command.WarehouseId;

    //    entity.Address = command.Address.ToEntity(new Address());

    //    return entity;
    //}

    //public static Order ToEntity(this UpdateOrderCommand command, Order entity)
    //{
    //    entity.Number = command.Number;
    //    entity.Date = command.Date;
    //    entity.StartTime = command.StartTime;
    //    entity.EndTime = command.EndTime;
    //    entity.WarehouseId = command.WarehouseId;

    //    _ = command.Address.ToEntity(entity.Address);

    //    return entity;
    //}

    public static Expression<Func<RouteSet, RouteSetListResult.ItemData>> ProjectList()
    {
        return order => new RouteSetListResult.ItemData
        {
            Id = order.Id,
            Name = order.Name,
            Date = order.Date,
            StartTime = order.StartTime,
            EndTime = order.EndTime
        };
    }
}
