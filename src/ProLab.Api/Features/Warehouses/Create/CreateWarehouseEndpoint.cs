using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Warehouses;

namespace ProLab.Api.Features.Warehouses.Create;

public class CreateWarehouseEndpoint : Endpoint<CreateWarehouseRequest, int>
{
    private readonly IWarehouseService _warehouseService;

    public CreateWarehouseEndpoint(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    public override void Configure()
    {
        Post("/");
        Group<WarehouseGroup>();
    }

    public override async Task HandleAsync(CreateWarehouseRequest request, CancellationToken cancellationToken)
    {
        Result<int> result = await _warehouseService.CreateAsync(request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
