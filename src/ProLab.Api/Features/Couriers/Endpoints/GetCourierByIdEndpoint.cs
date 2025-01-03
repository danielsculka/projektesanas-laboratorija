using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Couriers;
using ProLab.Application.Couriers.Results;
using ProLab.Shared.Couriers.Response;

namespace ProLab.Api.Features.Couriers.Endpoints;

public class GetCourierByIdEndpoint : EndpointWithoutRequest<GetCourierResponse>
{
    private readonly ICourierService _courierService;

    public GetCourierByIdEndpoint(ICourierService courierService)
    {
        _courierService = courierService;
    }

    public override void Configure()
    {
        Get("/{id}");
        Group<CourierGroup>();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        int courierId = Route<int>("id");

        Result<CourierResult> result = await _courierService.GetByIdAsync(courierId, cancellationToken);

        await this.SendResultAsync(result, result => result.ToResponse(), cancellationToken);
    }
}
