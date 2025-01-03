using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Couriers;
using ProLab.Shared.Couriers.Request;

namespace ProLab.Api.Features.Couriers.Endpoints;

public class CreateCourierEndpoint : Endpoint<CreateCourierRequest, int>
{
    private readonly ICourierService _courierService;

    public CreateCourierEndpoint(ICourierService courierService)
    {
        _courierService = courierService;
    }

    public override void Configure()
    {
        Post("/");
        Group<CourierGroup>();
    }

    public override async Task HandleAsync(CreateCourierRequest request, CancellationToken cancellationToken)
    {
        Result<int> result = await _courierService.CreateAsync(request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
