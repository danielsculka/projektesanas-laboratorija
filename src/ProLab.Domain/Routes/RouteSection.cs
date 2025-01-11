using ProLab.Domain.Orders;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Routes;

public class RouteSection : Entity<int>
{
    public int RouteId { get; set; }
    public virtual Route Route { get; set; }

    public int? FromOrderId { get; set; }
    public virtual Order FromOrder { get; set; }

    public int? ToOrderId { get; set; }
    public virtual Order ToOrder { get; set; }

    [Required]
    public string IntermediatePoints { get; set; }
}
