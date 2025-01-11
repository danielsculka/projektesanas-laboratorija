using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Routes;

public class RouteSet : Entity<int>
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
