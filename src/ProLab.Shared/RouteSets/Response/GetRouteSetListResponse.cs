using ProLab.Shared.Common;
using ProLab.Shared.Common.Response;

namespace ProLab.Shared.RouteSets.Response;

public class GetRouteSetListResponse : PagedListResponse<GetRouteSetListResponse.ItemData>
{
    public class ItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
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
                public IEnumerable<CoordinateData> Path { get; set; }
            }
        }
    }
}
