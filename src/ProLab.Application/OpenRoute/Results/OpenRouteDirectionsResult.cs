using NetTopologySuite.Geometries;

namespace ProLab.Application.OpenRoute.Results;

public class OpenRouteDirectionsResult
{
    public double Distance { get; set; }
    public double Duration { get; set; }
    public LineString Path { get; set; }
}
