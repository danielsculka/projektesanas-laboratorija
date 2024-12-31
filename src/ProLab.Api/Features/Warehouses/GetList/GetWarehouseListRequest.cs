using ProLab.Application.Common.Query;
using ProLab.Application.Warehouses.Query;

namespace ProLab.Api.Features.Warehouses.GetList;

public class GetWarehouseListRequest
{
    public WarehouseFilter? Filter { get; set; }
    public WarehouseSorting? Sorting { get; set; }
    public PagingParameters? Paging { get; set; }
}
