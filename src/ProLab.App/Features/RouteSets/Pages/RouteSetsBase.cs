using FisSst.BlazorMaps;
using Microsoft.AspNetCore.Components;
using ProLab.App.Features.Couriers;
using ProLab.App.Features.Orders;
using ProLab.App.Features.RouteSets.Dialogs;
using ProLab.App.Features.Warehouses;
using ProLab.App.Shared;
using ProLab.Shared.Common;
using ProLab.Shared.Couriers.Response;
using ProLab.Shared.Orders.Response;
using ProLab.Shared.RouteSets.Requests;
using ProLab.Shared.RouteSets.Response;
using ProLab.Shared.Warehouses.Response;
using Radzen;
using Radzen.Blazor;

namespace ProLab.App.Features.RouteSets.Pages;

public class RouteSetsBase : ComponentBase
{
    [Inject]
    public required DialogService DialogService { get; set; }

    [Inject]
    public required IWarehouseService WarehouseService { get; set; }
    [Inject]
    public required IOrderService OrderService { get; set; }
    [Inject]
    public required ICourierService CourierService { get; set; }
    [Inject]
    public required IRouteSetService RouteSetService { get; set; }

    [Inject]
    public required MapOptions DefaultMapOptions { get; set; }

    [Inject]
    private ICircleMarkerFactory CircleMarkerFactory { get; set; }
    [Inject]
    private IPolylineFactory PolylineFactory { get; init; }

    public Map Map;

    public RadzenDataGrid<GetRouteSetListResponse.ItemData> Grid;
    public GetRouteSetListResponse.ItemData SelectedItem;

    public bool IsLoading = false;

    public IEnumerable<GetWarehouseListResponse.ItemData> Warehouses;
    public IEnumerable<GetOrderListResponse.ItemData> Orders;
    public IEnumerable<GetCourierListResponse.ItemData> Couriers;
    public IEnumerable<GetRouteSetListResponse.ItemData> RouteSets;
    public int Count = 0;
    public int PageSize = 10;

    private string[] _routeColors;
    private string _warehouseColor = ColorGenerator.GenerateRandomColor();
    private string _orderColor = ColorGenerator.GenerateRandomColor();
    private List<Polyline> _routePolylines = new List<Polyline>();
    private List<CircleMarker> _warehouseMarkers = new List<CircleMarker>();
    private List<CircleMarker> _orderMarkers = new List<CircleMarker>();

    protected override async Task OnInitializedAsync()
    {
        await Load();

        await DrawWarehouses();
        await DrawOrders();
    }

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

        RouteSets = pagedList.Items;
        Count = pagedList.TotalCount;

        if (SelectedItem == null && RouteSets.Any())
            _ = Grid.SelectRow(RouteSets.First());

        IsLoading = false;
    }

    public async Task OnGenerate()
    {
        bool? result = await DialogService.OpenAsync<RouteSetGenerateDialog>("Generate routes");

        if (result.HasValue && result.Value)
            await Grid.RefreshDataAsync();
    }

    public async Task OnRowSelect(GetRouteSetListResponse.ItemData item)
    {
        foreach (var polyline in _routePolylines)
            _ = await polyline.RemoveFrom(Map);

        _routePolylines.Clear();

        SelectedItem = item;

        foreach (GetRouteSetListResponse.ItemData.RouteData route in SelectedItem.Routes)
        {
            GetCourierListResponse.ItemData courier = Couriers.First(courier => courier.Id == route.CourierId);

            var color = ColorGenerator.GenerateRandomColor();

            foreach (GetRouteSetListResponse.ItemData.RouteData.SectionData section in route.Sections)
            {
                IEnumerable<LatLng> c = section.Path
                    .Select(coordinate => new LatLng(coordinate.Latitude, coordinate.Longitude));

                Polyline polyline = await PolylineFactory.CreateAndAddToMap(c, Map, new PolylineOptions
                {
                    Color = color,
                    Opacity = 0.8
                });

                _ = await polyline.BindTooltip(
                    $"Courier: {courier.FirstName} {courier.LastName} " +
                    $"Arrival time: {section.ArrivalTime:HH:mm} " +
                    $"Duration: {Math.Round(section.Duration / 60, 2)} min " +
                    $"Distance: {section.Distance} km");

                _routePolylines.Add(polyline);
            }
        }
    }

    private async Task DrawWarehouses()
    {
        foreach (CircleMarker marker in _warehouseMarkers)
            _ = await marker.RemoveFrom(Map);

        _warehouseMarkers.Clear();

        foreach (GetWarehouseListResponse.ItemData warehouse in Warehouses)
        {
            var point = new LatLng(warehouse.Address.Location.Latitude, warehouse.Address.Location.Longitude);

            CircleMarker marker = await CircleMarkerFactory.CreateAndAddToMap(point, Map, new CircleMarkerOptions
            {
                Radius = 5,
                Color = _warehouseColor
            });

            _ = await marker.BindTooltip(
                $"Warehouse: {warehouse.Name} " +
                $"Address: {warehouse.Address}");

            _warehouseMarkers.Add(marker);
        }
    }

    private async Task DrawOrders()
    {
        foreach (CircleMarker marker in _orderMarkers)
            _ = await marker.RemoveFrom(Map);

        _orderMarkers.Clear();

        foreach (GetOrderListResponse.ItemData order in Orders)
        {
            var point = new LatLng(order.Address.Location.Latitude, order.Address.Location.Longitude);

            CircleMarker marker = await CircleMarkerFactory.CreateAndAddToMap(point, Map, new CircleMarkerOptions
            {
                Radius = 5,
                Color = _orderColor
            });

            _ = await marker.BindTooltip(
                $"Order: {order.Number} " +
                $"Address: {order.Address} " +
                $"Warehouse: {order.Warehouse.Name}");

            _orderMarkers.Add(marker);
        }
    }

    private async Task Load()
    {
        Task<GetWarehouseListResponse> warehousesTask = WarehouseService.GetListAsync();
        Task<GetOrderListResponse> ordersTask = OrderService.GetListAsync();
        Task<GetCourierListResponse> couriersTask = CourierService.GetListAsync();

        await Task.WhenAll(warehousesTask, ordersTask, couriersTask);

        Warehouses = (await warehousesTask).Items;
        Orders = (await ordersTask).Items;
        Couriers = (await couriersTask).Items;
    }
}

