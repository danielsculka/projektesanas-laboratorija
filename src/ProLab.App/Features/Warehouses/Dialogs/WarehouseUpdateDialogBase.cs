using Microsoft.AspNetCore.Components;
using ProLab.Shared.Common;
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
            Address = new AddressData
            {
                Street = warehouse.Address.Street,
                City = warehouse.Address.City,
                District = warehouse.Address.District,
                Parish = warehouse.Address.Parish,
                PostalCode = warehouse.Address.PostalCode,
                Location = warehouse.Address.Location
            }
        };
    }

    protected void Cancel()
    {
        DialogService.Close(false);
    }

    protected void Update()
    {
        _ = WarehouseService.UpdateAsync(WarehouseId, Warehouse);

        DialogService.Close(true);
    }
}
