using Microsoft.EntityFrameworkCore;
using ProLab.Domain.Users;

namespace ProLab.Infrastructure.Identity;

public interface IIdentityDbContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<User> Users { get; }
    //DbSet<UserLogin> IdentityUserLogins { get; }
}
