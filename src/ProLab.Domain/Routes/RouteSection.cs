using ProLab.Domain.Orders;

namespace ProLab.Domain.Routes;

public class RouteSection : Entity<Guid>
{
    public Guid RouteId { get; set; }
    public virtual required Route Route { get; set; }

    public Guid? FirstOrderId { get; set; }
    public virtual Order FirstOrder { get; set; }

    public Guid LastOrderId { get; set; }
    public virtual required Order LastOrder { get; set; }

    public required string IntermediatePoints { get; set; }
}
