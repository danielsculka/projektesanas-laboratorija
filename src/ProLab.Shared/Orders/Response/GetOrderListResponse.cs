using ProLab.Shared.Common;
using ProLab.Shared.Common.Response;

namespace ProLab.Shared.Orders.Response;

public class GetOrderListResponse : PagedListResponse<GetOrderListResponse.ItemData>
{
    public class ItemData
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public AddressData Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
