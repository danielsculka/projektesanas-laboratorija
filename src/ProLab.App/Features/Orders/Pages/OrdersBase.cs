using Microsoft.AspNetCore.Components;
using ProLab.App.Features.Orders.Dialogs;
using ProLab.Shared.Common;
using ProLab.Shared.Orders.Requests;
using ProLab.Shared.Orders.Response;
using Radzen;
using Radzen.Blazor;

namespace ProLab.App.Features.Orders.Pages;

public class OrdersBase : ComponentBase
{
    [Inject]
    public required IOrderService OrderService { get; set; }

    [Inject]
    public required DialogService DialogService { get; set; }

    protected RadzenDataGrid<GetOrderListResponse.ItemData> Grid;

    public bool IsLoading = false;

    public IEnumerable<GetOrderListResponse.ItemData> Items;
    public int Count = 0;
    public int PageSize = 5;

    public async Task LoadData(LoadDataArgs args)
    {
        IsLoading = true;

        await Task.Yield();

        var request = new GetOrderListRequest
        {
            Paging = new PagingData
            {
                CurrentPage = args.Skip.HasValue ? args.Skip.Value / PageSize + 1 : 1,
                PageSize = PageSize
            }
        };

        GetOrderListResponse pagedList = await OrderService.GetListAsync(request);

        Items = pagedList.Items;
        Count = pagedList.TotalCount;

        IsLoading = false;
    }

    public async Task OnAdd()
    {
        bool? result = await DialogService.OpenAsync<OrderCreateDialog>("Create order");

        if (result.HasValue && result.Value)
            await Grid.RefreshDataAsync();
    }

    public async Task OnEdit(GetOrderListResponse.ItemData order)
    {
        bool? result = await DialogService.OpenAsync<OrderUpdateDialog>(
            "Update order",
            new Dictionary<string, object>
            {
                { "OrderId", order.Id }
            });

        if (result.HasValue && result.Value)
            await Grid.RefreshDataAsync();
    }

    public async Task OnDelete(GetOrderListResponse.ItemData order)
    {
        var result = await DialogService.Confirm(
            "Are you sure?",
            "Delete order",
            new ConfirmOptions()
            {
                OkButtonText = "Yes",
                CancelButtonText = "No"
            });

        if (result.HasValue && result.Value)
        {
            await OrderService.DeleteAsync(order.Id);

            await Grid.RefreshDataAsync();
        }
    }
}

