using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Warehouses;

namespace ProLab.Api.Features.Warehouses.Delete;

public class DeleteWarehouseEndpoint : EndpointWithoutRequest
{
    private readonly IWarehouseService _warehouseService;

    public DeleteWarehouseEndpoint(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    public override void Configure()
    {
        Delete("/{id}");
        Group<WarehouseGroup>();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        int warehouseId = Route<int>("id");

        Result result = await _warehouseService.DeleteAsync(warehouseId, cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
