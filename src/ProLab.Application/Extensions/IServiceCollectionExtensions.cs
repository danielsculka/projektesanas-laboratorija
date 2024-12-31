using Microsoft.Extensions.DependencyInjection;
using ProLab.Application.Couriers;
using ProLab.Application.Orders;
using ProLab.Application.Routes;
using ProLab.Application.Warehouses;

namespace ProLab.Application.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        _ = services.AddScoped<ICourierService, CourierService>();
        _ = services.AddScoped<IWarehouseService, WarehouseService>();
        _ = services.AddScoped<IOrderService, OrderService>();
        _ = services.AddScoped<IRouteService, RouteService>();

        return services;
    }
}
