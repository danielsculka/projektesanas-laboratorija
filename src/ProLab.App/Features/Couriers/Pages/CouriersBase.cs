using Microsoft.AspNetCore.Components;
using ProLab.Shared.Common;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;
using Radzen;

namespace ProLab.App.Features.Couriers.Pages;

public class CouriersBase : ComponentBase
{
    [Inject]
    public ICourierService CourierService { get; set; }

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
}
