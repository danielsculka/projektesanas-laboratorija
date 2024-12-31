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

            ILogger<InstallationLogger> logger = scope.ServiceProvider.GetRequiredService<ILogger<InstallationLogger>>();

            try
            {
                logger.LogInformation("Migrate the database.");

                AppDbContextSetup.MigrateAsync(context).Wait();

                logger.LogInformation("Seed the database.");

                AppDbContextSetup.Seed(context);

                logger.LogInformation("Database setup finished.");
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "An error occurred while migrating or seeding the database.");
            }
        }

        return host;
    }
}
