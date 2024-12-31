using Microsoft.EntityFrameworkCore;
using ProLab.Domain.Couriers;
using ProLab.Domain.Orders;
using ProLab.Domain.Routes;
using ProLab.Domain.Users;
using ProLab.Domain.Warehouses;

namespace ProLab.Application;

public interface IAppDbContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<Courier> Couriers { get; }
    DbSet<Order> Orders { get; }
    DbSet<RouteSet> RouteSets { get; }
    DbSet<Warehouse> Warehouses { get; }
    DbSet<User> Users { get; }
}
