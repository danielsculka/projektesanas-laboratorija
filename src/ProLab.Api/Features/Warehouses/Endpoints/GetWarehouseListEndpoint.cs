using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Warehouses;
using ProLab.Application.Warehouses.Results;
using ProLab.Shared.Warehouses.Requests;
using ProLab.Shared.Warehouses.Response;

namespace ProLab.Api.Features.Warehouses.Endpoints;

public class GetWarehouseListEndpoint : Endpoint<GetWarehouseListRequest, GetWarehouseListResponse>
{
    private readonly IWarehouseService _warehouseService;

    public GetWarehouseListEndpoint(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    public override void Configure()
    {
        Get("/");
        Group<WarehouseGroup>();
    }

    public override async Task HandleAsync(GetWarehouseListRequest request, CancellationToken cancellationToken)
    {
        Result<WarehouseListResult> result = await _warehouseService
            .GetAsync(request.ToQueryParameters(), cancellationToken);

        await this.SendResultAsync(result, result => result.ToResponse(), cancellationToken);
    }
}
