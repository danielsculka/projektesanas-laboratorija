using ProLab.Shared.Common;
using ProLab.Shared.Common.Response;

namespace ProLab.Shared.Warehouses.Response;

public class GetWarehouseListResponse : PagedListResponse<GetWarehouseListResponse.ItemData>
{
    public class ItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressData Address { get; set; }
    }
}
