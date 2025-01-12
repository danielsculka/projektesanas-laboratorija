using FisSst.BlazorMaps;
using FisSst.BlazorMaps.DependencyInjection;
using ProLab.App.Features.Couriers;
using ProLab.App.Features.Orders;
using ProLab.App.Features.RouteSets;
using ProLab.App.Features.Warehouses;
using Radzen;

namespace ProLab.App.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddSingleton(new MapOptions
        {
            DivId = "mapId",
            Center = new LatLng(56.9496, 24.1052),
            Zoom = 11,
            UrlTileLayer = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        });

        _ = services.AddScoped<ICourierService, CourierService>();
        _ = services.AddScoped<IRouteSetService, RouteSetService>();
        _ = services.AddScoped<IWarehouseService, WarehouseService>();
        _ = services.AddScoped<IOrderService, OrderService>();

        _ = services.AddRadzenComponents();
        _ = services.AddBlazorLeafletMaps();

        return services;
    }
}
