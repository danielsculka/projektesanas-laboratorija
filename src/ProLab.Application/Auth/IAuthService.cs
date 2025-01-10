using FluentResults;
using ProLab.Application.Auth.Commands;
using ProLab.Domain.Users;

namespace ProLab.Application.Auth;
public interface IAuthService
{
    public string GenerateJWT(User user);
}
