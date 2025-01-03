namespace ProLab.Infrastructure.OpenRoute.Models;

public class OpenRouteDirectionsRequest
{
    public required double[][] Coordinates { get; set; }
    public required OpenRouteDirectionsUnits Units { get; set; }
}
