using ProLab.Shared.Common;

namespace ProLab.Shared.Warehouses.Requests;

public class GetWarehouseListRequest
{
    public WarehouseFilterData? Filter { get; set; }
    public SortingData? Sorting { get; set; }
    public PagingData? Paging { get; set; }
}
