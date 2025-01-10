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
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
