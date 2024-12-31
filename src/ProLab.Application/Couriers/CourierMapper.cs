using ProLab.Application.Couriers.Commands;
using ProLab.Application.Couriers.Results;
using ProLab.Domain.Couriers;
using System.Linq.Expressions;

namespace ProLab.Application.Couriers;

internal static class CourierMapper
{
    public static Courier ToEntity(this CreateCourierCommand command, Courier entity)
    {
        entity.FirstName = command.FirstName;
        entity.LastName = command.LastName;

        return entity;
    }

    public static Courier ToEntity(this UpdateCourierCommand command, Courier entity)
    {
        entity.FirstName = command.FirstName;
        entity.LastName = command.LastName;

        return entity;
    }

    public static Expression<Func<Courier, CourierResult>> Project()
    {
        return courier => new CourierResult
        {
            Id = courier.Id,
            FirstName = courier.FirstName,
            LastName = courier.LastName
        };
    }

    public static Expression<Func<Courier, CourierListResult.ItemData>> ProjectList()
    {
        return courier => new CourierListResult.ItemData
        {
            Id = courier.Id,
            FirstName = courier.FirstName,
            LastName = courier.LastName
        };
    }
}
