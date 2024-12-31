using ProLab.Domain.Couriers;

namespace ProLab.Domain.Routes;

public class Route : Entity<int>
{
    public int CourierId { get; set; }
    public virtual Courier Courier { get; set; }

    public int RouteSetId { get; set; }
    public virtual RouteSet RouteSet { get; set; }

    public virtual ICollection<RouteSection> Sections { get; set; } = new List<RouteSection>();
}
