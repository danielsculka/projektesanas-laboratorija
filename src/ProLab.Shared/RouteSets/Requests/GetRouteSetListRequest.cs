using ProLab.Shared.Common;

namespace ProLab.Shared.RouteSets.Requests;

public class GetRouteSetListRequest
{
    public RouteSetFilterData? Filter { get; set; }
    public SortingData? Sorting { get; set; }
    public PagingData? Paging { get; set; }
}
