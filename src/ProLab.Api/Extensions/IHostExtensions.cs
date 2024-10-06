using ProLab.Infrastructure.Database;

namespace ProLab.Api.Extensions;

public static class IHostExtensions
{
    public static IHost UpdateDatabase(this IHost host)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            IConfiguration config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            try
            {
                AppDbContextSetup.MigrateAsync(context).Wait();

                AppDbContextSetup.Seed(context);
            }
            catch (Exception)
            {
                //logger.LogError(ex, "An error occurred while migrating or seeding the database.");
            }
        }

        return host;
    }
}
