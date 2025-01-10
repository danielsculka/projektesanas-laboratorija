using FisSst.BlazorMaps;
using Microsoft.AspNetCore.Components;
using ProLab.App.Features.Couriers;
using ProLab.Shared.Common;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;
using Radzen;
using Radzen.Blazor;

namespace ProLab.App.Features.RouteSets.Pages;

public class RouteSetsBase : ComponentBase
{
    [Inject]
    public required IRouteSetService RouteSetService { get; set; }

    [Inject]
    public required ICourierService CourierService { get; set; }

    [Inject]
    public required MapOptions DefaultMapOptions { get; set; }
    [Inject]
    private IMarkerFactory MarkerFactory { get; init; }
    [Inject]
    private IPolygonFactory PolygonFactory { get; init; }

    public Map Map;
    public RadzenDataGrid<GetCourierListResponse.ItemData> Grid;

    public GetCourierListResponse.ItemData SelectedItem;

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

        if (SelectedItem == null && Items.Any())
            _ = Grid.SelectRow(Items.First());

        IsLoading = false;
    }

    public async Task OnRowSelect(GetCourierListResponse.ItemData item)
    {
        SelectedItem = item;

        // TODO: Create seperate map service that would have methods that allow to add polygons and delete them easelly

        LatLng FirstLatLng = new LatLng(50.2905456, 18.634743);
        LatLng SecondLatLng = new LatLng(50.287532, 18.615791);
        LatLng ThirdLatLng = new LatLng(50.295247, 18.579297);

        _ = await this.PolygonFactory.CreateAndAddToMap(new List<LatLng> { FirstLatLng, SecondLatLng, ThirdLatLng }, Map);
    }
}

