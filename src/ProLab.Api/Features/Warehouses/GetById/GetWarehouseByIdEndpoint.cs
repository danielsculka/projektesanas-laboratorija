using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Warehouses;
using ProLab.Application.Warehouses.Results;

namespace ProLab.Api.Features.Warehouses.GetById;

public class GetWarehouseByIdEndpoint : EndpointWithoutRequest<WarehouseResult>
{
    private readonly IWarehouseService _warehouseService;

    public GetWarehouseByIdEndpoint(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    public override void Configure()
    {
        Get("/{id}");
        Group<WarehouseGroup>();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        int warehouseId = Route<int>("id");

        Result<WarehouseResult> result = await _warehouseService.GetByIdAsync(warehouseId, cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
