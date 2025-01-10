using ProLab.Application.Addresses.Models;
using ProLab.Application.Common.Results;

namespace ProLab.Application.Orders.Results;

public class OrderListResult : PagedListResult<OrderListResult.ItemData>
{
    public OrderListResult(ItemData[] items, int totalCount, int? pageSize, int? currentPage)
        : base(items, totalCount, pageSize, currentPage)
    {
    }

    public class ItemData
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public AddressData Address { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
