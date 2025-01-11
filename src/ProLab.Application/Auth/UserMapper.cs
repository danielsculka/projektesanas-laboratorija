using ProLab.Application.Auth.Commands;
using ProLab.Application.Couriers.Commands;
using ProLab.Application.Couriers.Results;
using ProLab.Domain.Couriers;
using ProLab.Domain.Users;

namespace ProLab.Application.Auth;
internal static class UserMapper
{
    public static User ToEntity(this CreateUserCommand command, User entity)
    {
        entity.Name = command.UserName;
        entity.PasswordHash = command.PasswordHash;

        return entity;
    }

    //public static Expression<Func<User, User>> Project()
    //{
    //    return courier => new CourierResult
    //    {
    //        Id = courier.Id,
    //        FirstName = courier.FirstName,
    //        LastName = courier.LastName
    //    };
    //}

    //public static Expression<Func<Courier, CourierListResult.ItemData>> ProjectList()
    //{
    //    return courier => new CourierListResult.ItemData
    //    {
    //        Id = courier.Id,
    //        FirstName = courier.FirstName,
    //        LastName = courier.LastName
    //    };
    //}
}
