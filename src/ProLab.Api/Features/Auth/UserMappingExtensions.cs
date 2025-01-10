using ProLab.Application.Auth.Commands;
using ProLab.Application.Couriers.Commands;
using ProLab.Shared.Auth.Request;
using ProLab.Shared.Couriers.Request;

namespace ProLab.Api.Features.Auth;

internal static class UserMappingExtensions
{
    public static CreateUserCommand ToCommand(this CreateUserRequest request)
    {
        return new CreateUserCommand
        {
            UserName = request.UserName,
            PasswordHash = request.Password
        };
    }
}
