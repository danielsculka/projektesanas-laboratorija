using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProLab.Application.Auth.Commands;
using ProLab.Application.Common.Errors;
using ProLab.Application.Orders;
using ProLab.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProLab.Application.Auth;
public class AuthService : IAuthService
{
    private readonly IAppDbContext _db;
    private readonly ILogger<AuthService> _logger;
    private readonly JwtOptions _options;

    public AuthService(IAppDbContext db,
        ILogger<AuthService> logger,
        IOptions<JwtOptions> options)
    {
        _db = db;
        _logger = logger;
        _options = options.Value;
    }

    public string GenerateJWT(User user)
    {
        Claim[] claims = [new("userId", user.Id.ToString())];

        var signingCredetnials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256
            );

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredetnials,
            expires: DateTime.UtcNow.AddHours(_options.ExpiresHours)
            );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }

    //public async Task<Result<string>> Login(CreateLoginCommand command, CancellationToken cancellationToken = default)
    //{

    //    string token = GenerateJWT(user);

    //    return Result.Ok(token);
    //}
}
