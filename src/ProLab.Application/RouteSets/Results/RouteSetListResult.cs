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
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        // TODO: Add routes data
    }
}
