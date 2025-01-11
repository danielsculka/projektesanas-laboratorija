using Microsoft.AspNetCore.Components;
using ProLab.Shared.Orders.Requests;
using ProLab.Shared.Orders.Response;
using Radzen;

namespace ProLab.App.Features.Orders.Dialogs;

public class OrderUpdateDialogBase : ComponentBase
{
    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    public IOrderService OrderService { get; set; }

    [Parameter]
    public int OrderId { get; set; }

    public UpdateOrderRequest Order { get; set; } = new UpdateOrderRequest
    {
        Date = DateOnly.FromDateTime(DateTime.Now),
        StartTime = new TimeOnly(8, 0),
        EndTime = new TimeOnly(12, 0)
    };

    protected override async Task OnInitializedAsync()
    {
        GetOrderResponse order = await OrderService.GetByIdAsync(OrderId);

        Order = new UpdateOrderRequest
        {
            Number = order.Number,
            Address = order.Address,
            Date = order.Date,
            StartTime = order.StartTime,
            EndTime = order.EndTime,
            WarehouseId = order.WarehouseId
        };
    }

    protected void Cancel()
    {
        DialogService.Close(false);
    }

    protected async Task Update()
    {
        await OrderService.UpdateAsync(OrderId, Order);

        DialogService.Close(true);
    }
}
