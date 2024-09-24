using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProLab.Application;
using ProLab.Domain;
using ProLab.Domain.Couriers;
using ProLab.Domain.Users;

namespace ProLab.Infrastructure.Database;

public class AppDbContext : DbContext, IAppDbContext
{
    //private readonly ICurrentUserService _currentUser;

    public AppDbContext(
        DbContextOptions<AppDbContext> options
        //ICurrentUserService currentUser
        ) : base(options)
    {
        //_currentUser = currentUser;
    }

    public DbSet<Courier> Couriers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => _ = optionsBuilder.UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConvertEnumToString(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        PrepareEntries();

        int result;

        try
        {
            result = base.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new DatabaseException(DatabaseException.DefaultMessage, ex);
        }

        return result;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        PrepareEntries();

        int result;

        try
        {
            result = await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            throw new DatabaseException(DatabaseException.DefaultMessage, ex);
        }

        return result;
    }

    private void ConvertEnumToString(ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            foreach (IMutableProperty property in entityType.GetProperties())
            {
                Type nullableType = Nullable.GetUnderlyingType(property.ClrType);

                if (property.ClrType.IsEnum || nullableType?.IsEnum == true)
                {
                    Type type = typeof(EnumToStringConverter<>).MakeGenericType(nullableType ?? property.ClrType);
                    var converter = Activator.CreateInstance(type, new ConverterMappingHints()) as ValueConverter;

                    property.SetValueConverter(converter);
                }
            }
    }

    private void PrepareEntries()
    {
        //DateTime now = DateTime.UtcNow;
        //Guid userId = _currentUser.Id;

        _ = ChangeTracker.Entries();

        foreach (EntityEntry entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Entity<Guid>)
            {
                var guidEntry = entry.Entity as Entity<Guid>;

                if (guidEntry.Id == Guid.Empty)
                    throw new Exception("Empty GUIDs are not allowed.");
            }

            //if (entry.Entity is IAuditable)
            //{
            //    var auditableEntry = entry.Entity as IAuditable;

            //    if (entry.State == EntityState.Added)
            //    {
            //        auditableEntry.Created = now;
            //        auditableEntry.CreatedById = userId;
            //        auditableEntry.Modified = now;
            //        auditableEntry.ModifiedById = userId;
            //    }
            //    else if (entry.State == EntityState.Modified)
            //    {
            //        auditableEntry.Modified = now;
            //        auditableEntry.ModifiedById = userId;
            //    }
            //    else if (entry.State == EntityState.Deleted)
            //    {
            //        auditableEntry.Modified = now;
            //        auditableEntry.ModifiedById = userId;
            //    }
            //}
        }
    }
}
