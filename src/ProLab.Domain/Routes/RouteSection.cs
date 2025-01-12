using NetTopologySuite.Geometries;
using ProLab.Domain.Orders;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Routes;

public class RouteSection : Entity<int>
{
    public int RouteId { get; set; }
    public virtual Route Route { get; set; }

    public int? OrderId { get; set; }
    public virtual Order Order { get; set; }

    public TimeOnly ArrivalTime { get; set; }
    public double Distance { get; set; }
    public double Duration { get; set; }

    [Required]
    public LineString Path { get; set; }
}
