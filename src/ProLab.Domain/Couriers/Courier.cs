using ProLab.Domain.Routes;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Couriers;

public class Courier : Entity<int>
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(30)]
    public string LastName { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
