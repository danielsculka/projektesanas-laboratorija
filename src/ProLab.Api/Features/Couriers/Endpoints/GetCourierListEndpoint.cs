using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Couriers;
using ProLab.Application.Couriers.Results;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;

namespace ProLab.Api.Features.Couriers.Endpoints;

public class GetCourierListEndpoint : Endpoint<GetCourierListRequest, GetCourierListResponse>
{
    private readonly ICourierService _courierService;

    public GetCourierListEndpoint(ICourierService courierService)
    {
        _courierService = courierService;
    }

    public override void Configure()
    {
        Get("/");
        Group<CourierGroup>();
    }

    public override async Task HandleAsync(GetCourierListRequest request, CancellationToken cancellationToken)
    {
        Result<CourierListResult> result = await _courierService
            .GetAsync(request.ToQueryParameters(), cancellationToken);

        await this.SendResultAsync(result, result => result.ToResponse(), cancellationToken);
    }
}
