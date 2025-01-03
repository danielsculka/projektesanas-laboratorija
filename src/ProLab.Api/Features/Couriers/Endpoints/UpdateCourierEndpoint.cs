using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Couriers;
using ProLab.Shared.Couriers.Request;

namespace ProLab.Api.Features.Couriers.Endpoints;

public class UpdateCourierEndpoint : Endpoint<UpdateCourierRequest>
{
    private readonly ICourierService _courierService;

    public UpdateCourierEndpoint(ICourierService courierService)
    {
        _courierService = courierService;
    }

    public override void Configure()
    {
        Put("/{id}");
        Group<CourierGroup>();
    }

    public override async Task HandleAsync(UpdateCourierRequest request, CancellationToken cancellationToken)
    {
        int courierId = Route<int>("id");

        Result result = await _courierService.UpdateAsync(courierId, request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
