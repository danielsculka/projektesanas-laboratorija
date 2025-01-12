using NetTopologySuite.Geometries;
using ProLab.Application.Common.Results;

namespace ProLab.Application.RouteSets.Results;

public class RouteSetListResult : PagedListResult<RouteSetListResult.ItemData>
{
    public RouteSetListResult(ItemData[] items, int totalCount, int? pageSize, int? currentPage)
        : base(items, totalCount, pageSize, currentPage)
    {
    }

    public class ItemData
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public TimeSpan GenerateDuration { get; set; }
        public IEnumerable<RouteData> Routes { get; set; }

        public class RouteData
        {
            public int Id { get; set; }
            public int CourierId { get; set; }
            public IEnumerable<SectionData> Sections { get; set; }

            public class SectionData
            {
                public int Id { get; set; }
                public int? OrderId { get; set; }
                public TimeOnly ArrivalTime { get; set; }
                public double Distance { get; set; }
                public double Duration { get; set; }
                public LineString Path { get; set; }
            }
        }
    }
}
