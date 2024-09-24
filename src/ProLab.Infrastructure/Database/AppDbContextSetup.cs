using Microsoft.EntityFrameworkCore;

namespace ProLab.Infrastructure.Database;

public static class AppDbContextSetup
{
    public static Task MigrateAsync(AppDbContext context) => context.Database.MigrateAsync();

    public static void Seed(AppDbContext context) { }
}
