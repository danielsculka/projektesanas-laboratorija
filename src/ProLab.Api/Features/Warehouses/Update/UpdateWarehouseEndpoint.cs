using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Warehouses;

namespace ProLab.Api.Features.Warehouses.Update;

public class UpdateWarehouseEndpoint : Endpoint<UpdateWarehouseRequest>
{
    private readonly IWarehouseService _warehouseService;

    public UpdateWarehouseEndpoint(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    public override void Configure()
    {
        Put("/{id}");
        Group<WarehouseGroup>();
    }

    public override async Task HandleAsync(UpdateWarehouseRequest request, CancellationToken cancellationToken)
    {
        int warehouseId = Route<int>("id");

        Result result = await _warehouseService.UpdateAsync(warehouseId, request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
