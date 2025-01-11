using Microsoft.AspNetCore.Components;
using ProLab.Shared.Warehouses.Requests;
using ProLab.Shared.Warehouses.Response;
using Radzen;

namespace ProLab.App.Features.Warehouses.Dialogs;

public class WarehouseUpdateDialogBase : ComponentBase
{
    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    public IWarehouseService WarehouseService { get; set; }

    [Parameter]
    public int WarehouseId { get; set; }

    public UpdateWarehouseRequest Warehouse { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        GetWarehouseResponse warehouse = await WarehouseService.GetByIdAsync(WarehouseId);

        Warehouse = new UpdateWarehouseRequest
        {
            Name = warehouse.Name,
            Address = warehouse.Address
        };
    }

    protected void Cancel()
    {
        DialogService.Close(false);
    }

    protected async Task Update()
    {
        await WarehouseService.UpdateAsync(WarehouseId, Warehouse);

        DialogService.Close(true);
    }
}
