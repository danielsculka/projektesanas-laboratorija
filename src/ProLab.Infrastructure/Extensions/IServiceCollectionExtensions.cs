using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProLab.Application;
using ProLab.Application.OpenRoute;
using ProLab.Infrastructure.Database;
using ProLab.Infrastructure.OpenRoute;

namespace ProLab.Infrastructure.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
            ?? configuration.GetConnectionString("Default");

        _ = services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString, o => o.UseNetTopologySuite()));

        _ = services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>()!);

        _ = services.Configure<OpenRouteOptions>(options =>
        {
            IConfigurationSection openRoute = configuration.GetSection("OpenRoute");

            options.Url = openRoute.GetValue<string>("Url")!;
            options.UserToken = Environment.GetEnvironmentVariable("OPENROUTE_USER_TOKEN")
                ?? openRoute.GetValue<string>("UserToken")!;
        });

        _ = services.AddHttpClient<IOpenRouteClient, OpenRouteClient>();
        _ = services.AddScoped<IOpenRouteService, OpenRouteService>();

        return services;
    }
}
