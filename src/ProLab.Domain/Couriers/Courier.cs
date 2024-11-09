using ProLab.Domain.Routes;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Couriers;

public class Courier : Entity<Guid>
{
    [MaxLength(30)]
    public required string FirstName { get; set; }

    [MaxLength(30)]
    public required string LastName { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
