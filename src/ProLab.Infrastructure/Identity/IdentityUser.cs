using ProLab.Domain;
using ProLab.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Infrastructure.Identity;

public class IdentityUser : Entity<Guid>
{

    [MaxLength(100)]
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }

    [MaxLength(32)]
    public required string PasswordResetKey { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
