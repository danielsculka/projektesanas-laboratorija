using Microsoft.AspNetCore.Components;
using ProLab.Shared.Orders.Requests;
using Radzen;

namespace ProLab.App.Features.Orders.Dialogs;

public class OrderCreateDialogBase : ComponentBase
{
    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    public IOrderService OrderService { get; set; }

    public CreateOrderRequest Order { get; set; } = new CreateOrderRequest
    {
        StartTime = new TimeOnly(8, 0),
        EndTime = new TimeOnly(12, 0)
    };

    protected void Cancel()
    {
        DialogService.Close(false);
    }

    protected async Task Create()
    {
        _ = await OrderService.CreateAsync(Order);

        DialogService.Close(true);
    }
}
