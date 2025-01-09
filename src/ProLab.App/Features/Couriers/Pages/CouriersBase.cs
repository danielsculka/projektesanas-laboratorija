using Microsoft.AspNetCore.Components;
using ProLab.App.Features.Couriers.Dialogs;
using ProLab.Shared.Common;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;
using Radzen;
using Radzen.Blazor;

namespace ProLab.App.Features.Couriers.Pages;

public class CouriersBase : ComponentBase
{
    [Inject]
    public required ICourierService CourierService { get; set; }

    [Inject]
    public required DialogService DialogService { get; set; }

    protected RadzenDataGrid<GetCourierListResponse.ItemData> Grid;

    public bool IsLoading = false;

    public IEnumerable<GetCourierListResponse.ItemData> Items;
    public int Count = 0;
    public int PageSize = 5;

    public async Task LoadData(LoadDataArgs args)
    {
        IsLoading = true;

        await Task.Yield();

        var request = new GetCourierListRequest
        {
            Paging = new PagingData
            {
                CurrentPage = args.Skip.HasValue ? (args.Skip.Value / PageSize) + 1 : 1,
                PageSize = PageSize
            }
        };

        GetCourierListResponse pagedList = await CourierService.GetListAsync(request);

        Items = pagedList.Items;
        Count = pagedList.TotalCount;

        IsLoading = false;
    }

    public async Task OnAdd()
    {
        bool? result = await DialogService.OpenAsync<CourierCreateDialog>("Create courier");

        if (result.HasValue && result.Value)
        {
            await Grid.RefreshDataAsync();
        }
    }

    public async Task OnEdit(GetCourierListResponse.ItemData courier)
    {
        bool? result = await DialogService.OpenAsync<CourierUpdateDialog>(
            "Update courier",
            new Dictionary<string, object>
            {
                { "CourierId", courier.Id }
            });

        if (result.HasValue && result.Value)
        {
            await Grid.RefreshDataAsync();
        }
    }

    public async Task OnDelete(GetCourierListResponse.ItemData courier)
    {
        var result = await DialogService.Confirm(
            "Are you sure?",
            "Delete courier",
            new ConfirmOptions()
            {
                OkButtonText = "Yes",
                CancelButtonText = "No"
            });

        if (result.HasValue && result.Value)
        {
            _ = CourierService.DeleteAsync(courier.Id);

            await Grid.RefreshDataAsync();
        }
    }
}

