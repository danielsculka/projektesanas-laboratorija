using Microsoft.EntityFrameworkCore;
using ProLab.Domain.Addresses;
using ProLab.Domain.Couriers;
using ProLab.Domain.Users;
namespace ProLab.Application;

public interface IAppDbContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<Courier> Couriers { get; }
    DbSet<Address> Addresses { get; }
    DbSet<User> Users { get; }
}
