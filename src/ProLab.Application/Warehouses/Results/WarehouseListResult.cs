using ProLab.Application.Addresses.Models;
using ProLab.Application.Common.Results;

namespace ProLab.Application.Warehouses.Results;

public class WarehouseListResult : PagedListResult<WarehouseListResult.ItemData>
{
    public WarehouseListResult(ItemData[] items, int totalCount, int? pageSize, int? currentPage)
        : base(items, totalCount, pageSize, currentPage)
    {
    }

    public class ItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressData Address { get; set; }
    }
}
