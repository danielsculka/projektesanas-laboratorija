using ProLab.Shared.Common;
using ProLab.Shared.Common.Response;

namespace ProLab.Shared.Orders.Response;

public class GetOrderListResponse : PagedListResponse<GetOrderListResponse.ItemData>
{
    public class ItemData
    {
        public int Id { get; set; }
        public required string Number { get; set; }
        public required AddressData Address { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public required WarehouseData Warehouse { get; set; }

        public class WarehouseData
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString() => Name;
        }
    }
}
