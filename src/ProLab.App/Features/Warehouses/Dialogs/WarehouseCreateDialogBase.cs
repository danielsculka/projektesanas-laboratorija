using Microsoft.AspNetCore.Components;
using ProLab.Shared.Warehouses.Requests;
using Radzen;

namespace ProLab.App.Features.Warehouses.Dialogs;

public class WarehouseCreateDialogBase : ComponentBase
{
    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    public IWarehouseService WarehouseService { get; set; }

    public CreateWarehouseRequest Warehouse { get; set; } = new();

    protected void Cancel()
    {
        DialogService.Close(false);
    }

    protected async Task Create()
    {
        _ = await WarehouseService.CreateAsync(Warehouse);

        DialogService.Close(true);
    }
}
