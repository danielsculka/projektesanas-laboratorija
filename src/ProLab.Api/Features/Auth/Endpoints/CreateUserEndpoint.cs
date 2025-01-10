using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Api.Features.Orders;
using ProLab.Application.Auth;
using ProLab.Domain.Users;
using ProLab.Infrastructure.Identity;
using ProLab.Shared.Auth.Request;

namespace ProLab.Api.Features.Auth.Endpoints;

public class CreateUserEndpoint : Endpoint<CreateUserRequest, int>
{
    private readonly IIdentityService _service;
    private readonly IPasswordService _hasher;

    public CreateUserEndpoint(IIdentityService service, IPasswordService hasher)
    {
        _service = service;
        _hasher = hasher;
    }

    public override void Configure()
    {
        Post("register");
        Group<AuthGroup>();
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        request.Password = _hasher.GeneratePasswordHash(request.Password);

        Result result = await _service.Register(request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
