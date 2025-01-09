using Microsoft.AspNetCore.Components;
using ProLab.Shared.Couriers.Request;
using Radzen;

namespace ProLab.App.Features.Couriers.Dialogs;

public class CourierCreateDialogBase : ComponentBase
{
    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    public ICourierService CourierService { get; set; }

    public CreateCourierRequest Courier { get; set; } = new();

    protected void Cancel()
    {
        DialogService.Close(false);
    }

    protected void Create()
    {
        _ = CourierService.CreateAsync(Courier);

        DialogService.Close(true);
    }
}
