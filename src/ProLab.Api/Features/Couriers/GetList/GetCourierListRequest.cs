using ProLab.Application.Common.Query;
using ProLab.Application.Couriers.Query;

namespace ProLab.Api.Features.Couriers.GetList;

public class GetCourierListRequest
{
    public CourierFilter? Filter { get; set; }
    public CourierSorting? Sorting { get; set; }
    public PagingParameters? Paging { get; set; }
}
