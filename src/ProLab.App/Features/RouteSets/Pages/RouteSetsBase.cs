﻿using FisSst.BlazorMaps;
using Microsoft.AspNetCore.Components;
using ProLab.App.Features.RouteSets.Dialogs;
using ProLab.Shared.Common;
using ProLab.Shared.RouteSets.Requests;
using ProLab.Shared.RouteSets.Response;
using Radzen;
using Radzen.Blazor;

namespace ProLab.App.Features.RouteSets.Pages;

public class RouteSetsBase : ComponentBase
{
    [Inject]
    public required DialogService DialogService { get; set; }

    [Inject]
    public required IRouteSetService RouteSetService { get; set; }

    [Inject]
    public required MapOptions DefaultMapOptions { get; set; }
    //[Inject]
    //private IMarkerFactory MarkerFactory { get; init; }
    //[Inject]
    //private IPolygonFactory PolygonFactory { get; init; }

    public Map Map;

    public RadzenDataGrid<GetRouteSetListResponse.ItemData> Grid;
    public GetRouteSetListResponse.ItemData SelectedItem;

    public bool IsLoading = false;

    public IEnumerable<GetRouteSetListResponse.ItemData> Items;
    public int Count = 0;
    public int PageSize = 10;

    public async Task LoadData(LoadDataArgs args)
    {
        IsLoading = true;

        await Task.Yield();

        var request = new GetRouteSetListRequest
        {
            Paging = new PagingData
            {
                CurrentPage = args.Skip.HasValue ? (args.Skip.Value / PageSize) + 1 : 1,
                PageSize = PageSize
            }
        };

        GetRouteSetListResponse pagedList = await RouteSetService.GetListAsync(request);

        Items = pagedList.Items;
        Count = pagedList.TotalCount;

        if (SelectedItem == null && Items.Any())
            _ = Grid.SelectRow(Items.First());

        IsLoading = false;
    }

    public async Task OnGenerate()
    {
        bool? result = await DialogService.OpenAsync<RouteSetGenerateDialog>("Generate routes");

        if (result.HasValue && result.Value)
            await Grid.RefreshDataAsync();
    }

    public void OnRowSelect(GetRouteSetListResponse.ItemData item)
    {
        SelectedItem = item;

        //// TODO: Create seperate map service that would have methods that allow to add polygons and delete them easelly

        //LatLng FirstLatLng = new LatLng(50.2905456, 18.634743);
        //LatLng SecondLatLng = new LatLng(50.287532, 18.615791);
        //LatLng ThirdLatLng = new LatLng(50.295247, 18.579297);

        //_ = await this.PolygonFactory.CreateAndAddToMap(new List<LatLng> { FirstLatLng, SecondLatLng, ThirdLatLng }, Map);
    }
}
