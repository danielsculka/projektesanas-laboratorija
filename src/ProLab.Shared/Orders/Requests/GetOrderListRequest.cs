using ProLab.Shared.Common;

namespace ProLab.Shared.Orders.Requests;

public class GetOrderListRequest
{
    public OrderFilterData? Filter { get; set; }
    public SortingData? Sorting { get; set; }
    public PagingData? Paging { get; set; }
}
