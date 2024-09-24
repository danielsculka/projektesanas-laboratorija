using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Users;

public class User : Entity<Guid>
{
    public User(string name) : this(Guid.NewGuid(), name) { }

    public User(Guid id, string name, UserRole role = UserRole.Administrator)
    {
        Id = id;
        Name = name;
        Role = role;
    }

    [MaxLength(100)]
    public string Name { get; set; }
    public UserRole Role { get; set; }
}
