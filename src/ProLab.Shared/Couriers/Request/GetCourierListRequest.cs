using ProLab.Shared.Common;

namespace ProLab.Shared.Couriers.Request;

public class GetCourierListRequest
{
    public CourierFilterData? Filter { get; set; }
    public SortingData? Sorting { get; set; }
    public PagingData? Paging { get; set; }
}
