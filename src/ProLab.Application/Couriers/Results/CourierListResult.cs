using ProLab.Application.Common.Results;

namespace ProLab.Application.Couriers.Results;

public class CourierListResult : PagedListResult<CourierListResult.ItemData>
{
    public CourierListResult(ItemData[] items, int totalCount, int? pageSize, int? currentPage)
        : base(items, totalCount, pageSize, currentPage)
    {
    }

    public class ItemData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
