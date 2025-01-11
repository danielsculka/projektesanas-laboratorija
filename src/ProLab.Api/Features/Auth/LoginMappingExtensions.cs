using ProLab.Application.Auth;
using ProLab.Application.Auth.Commands;
using ProLab.Infrastructure.Identity;
using ProLab.Shared.Auth.Request;

namespace ProLab.Api.Features.Auth;

internal static class LoginMappingExtensions
{
    public static CreateLoginCommand ToCommand(this CreateLoginRequest request, IPasswordService _hasher)
    {
        return new CreateLoginCommand
        {
            UserName = request.UserName,
            PasswordHash = _hasher.GeneratePasswordHash(request.Password)
        };
    }
}
