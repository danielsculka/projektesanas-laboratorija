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
    }
}
