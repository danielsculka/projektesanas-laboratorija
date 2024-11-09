using ProLab.Domain.Couriers;

namespace ProLab.Domain.Routes;

public class Route : Entity<Guid>
{
    public Guid CourierId { get; set; }
    public virtual required Courier Courier { get; set; }

    public virtual ICollection<RouteSection> Sections { get; set; } = new List<RouteSection>();
}
