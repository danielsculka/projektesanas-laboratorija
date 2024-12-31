using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Couriers;

namespace ProLab.Api.Features.Couriers.Delete;

public class DeleteCourierEndpoint : EndpointWithoutRequest
{
    private readonly ICourierService _courierService;

    public DeleteCourierEndpoint(ICourierService courierService)
    {
        _courierService = courierService;
    }

    public override void Configure()
    {
        Delete("/{id}");
        Group<CourierGroup>();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        int courierId = Route<int>("id");

        Result result = await _courierService.DeleteAsync(courierId, cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
