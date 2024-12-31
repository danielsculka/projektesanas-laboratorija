using ProLab.Domain.Orders;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Routes;

public class RouteSection : Entity<int>
{
    public int RouteId { get; set; }
    public virtual Route Route { get; set; }

    public int? FirstOrderId { get; set; }
    public virtual Order FirstOrder { get; set; }

    public int? LastOrderId { get; set; }
    public virtual Order LastOrder { get; set; }

    [Required]
    public string IntermediatePoints { get; set; }
}
