namespace ProLab.Infrastructure.OpenRoute.Models;

public class OpenRouteDirectionsResponse
{
    public IEnumerable<RouteData> Routes { get; set; }

    public class RouteData
    {
        public SummaryData Summary { get; set; }

        public class SummaryData
        {
            public double Distance { get; set; }
            public double Duration { get; set; }
        }
    }
}
