using Microsoft.AspNetCore.Components;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;
using Radzen;

namespace ProLab.App.Features.Couriers.Dialogs;

public class CourierUpdateDialogBase : ComponentBase
{
    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    public ICourierService CourierService { get; set; }

    [Parameter]
    public int CourierId { get; set; }

    public UpdateCourierRequest Courier { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        GetCourierResponse courier = await CourierService.GetByIdAsync(CourierId);

        Courier = new UpdateCourierRequest
        {
            FirstName = courier.FirstName,
            LastName = courier.LastName
        };
    }

    protected void Cancel()
    {
        DialogService.Close(false);
    }

    protected void Update()
    {
        _ = CourierService.UpdateAsync(CourierId, Courier);

        DialogService.Close(true);
    }
}
