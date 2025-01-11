using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using ProLab.Api.Features.Orders;
using ProLab.Application.Auth;
using ProLab.Domain.Users;
using ProLab.Infrastructure.Identity;
using ProLab.Shared.Auth.Request;

namespace ProLab.Api.Features.Auth.Endpoints;

public class CreateLoginEndpoint : Endpoint<CreateLoginRequest, int>
{
    private readonly IIdentityService _service;
    private readonly IPasswordService _hasher;
    private readonly IAuthService _authService;

    public CreateLoginEndpoint(IIdentityService service, IPasswordService hasher, IAuthService authService)
    {
        _service = service;
        _hasher = hasher;
        _authService = authService;
    }

    public override void Configure()
    {
        Post("login");
        Group<AuthGroup>();
    }

    public override async Task<IResult> HandleAsync(CreateLoginRequest login, CancellationToken cancelationToken = default)
    {
        var user = await _service.Login(login.ToCommand(_hasher), cancelationToken);

        var token = _authService.GenerateJWT(user.Value);

        HttpContext.Response.Cookies.Append("auth-token", token);

        return Results.Ok(token);
    }
}
