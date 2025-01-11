using Microsoft.AspNetCore.Components;
using ProLab.Shared.Common;
using ProLab.Shared.Warehouses.Requests;
using ProLab.Shared.Warehouses.Response;
using Radzen;
using Radzen.Blazor;

namespace ProLab.App.Features.Warehouses.Components;

public class WarehouseListBoxBase : ComponentBase
{
    [Inject]
    public required IWarehouseService WarehouseService { get; set; }

    [Parameter]
    public int WarehouseId { get; set; }

    [Parameter]
    public EventCallback<int> WarehouseIdChanged { get; set; }

    protected RadzenListBox<int> ListBox;

    public IEnumerable<GetWarehouseListResponse.ItemData> Items;
    public int PageSize = 3;

    protected async Task OnChange()
    {
        await WarehouseIdChanged.InvokeAsync(WarehouseId);
    }

    protected async Task LoadData(LoadDataArgs args)
    {
        if (string.IsNullOrEmpty(args.Filter) && WarehouseId != 0)
        {
            GetWarehouseResponse warehouse = await WarehouseService.GetByIdAsync(WarehouseId);

            ListBox.SearchText = warehouse.Name;
            args.Filter = warehouse.Name;
        }

        var request = new GetWarehouseListRequest
        {
            Filter = string.IsNullOrEmpty(args.Filter)
                ? null
                : new WarehouseFilterData
                {
                    Search = args.Filter
                },
            Paging = new PagingData
            {
                CurrentPage = 1,
                PageSize = PageSize
            }
        };

        GetWarehouseListResponse pagedList = await WarehouseService.GetListAsync(request);

        Items = pagedList.Items;

        if (WarehouseId == 0)
            WarehouseId = Items.First().Id;
    }
}
