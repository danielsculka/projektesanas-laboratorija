using Microsoft.AspNetCore.Components;
using ProLab.Shared.Common;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;
using Radzen;
using Radzen.Blazor;
using ProLab.App.Features.Couriers.CourierForms;
using ProLab.Shared.Couriers.Response;

namespace ProLab.App.Features.Couriers.Pages;

public class CouriersBase : ComponentBase
{
    [Inject]
    public ICourierService CourierService { get; set; }

    [Inject]
    public DialogService DialogService { get; set; }

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

        var pagedList = await CourierService.GetListAsync(request);

        Items = pagedList.Items;
        Count = pagedList.TotalCount;

        IsLoading = false;
    }

    public async Task OnAddClick()
    {
        var newCourier = new GetCourierListResponse.ItemData();

        CreateCourierRequest result = await DialogService.OpenAsync<CourierForm>("Add courier", new Dictionary<string, object>
    {
        { "Courier", newCourier }
    });

        if (result != null)
        {
            CourierService.CreateAsync(result);
        }

    }

    public async Task OnEditClick(GetCourierListResponse.ItemData courier)
    {
        UpdateCourierRequest result = await DialogService.OpenAsync<CourierForm>("Edit courier", new Dictionary<string, object>
    {
        { "Courier", courier }
    });

        if (result != null)
        {
            CourierService.UpdateAsync(courier.Id, result);
        }

    }

    public async Task OnDeleteClick(GetCourierListResponse.ItemData courier)
    {
        var confirmed = await DialogService.Confirm("Are you sure?", "Delete courier " + courier.Id, new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });

        if (confirmed == true)
        {
            CourierService.DeleteAsync(courier.Id);
        }

    }
}

