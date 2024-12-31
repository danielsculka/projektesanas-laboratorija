using ProLab.Application.Common.Query;
using ProLab.Application.Orders.Query;

namespace ProLab.Api.Features.Orders.GetList;

public class GetOrderListRequest
{
    public OrderFilter? Filter { get; set; }
    public OrderSorting? Sorting { get; set; }
    public PagingParameters? Paging { get; set; }
}
