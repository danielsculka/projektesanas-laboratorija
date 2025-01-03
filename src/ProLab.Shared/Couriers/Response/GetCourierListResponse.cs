using ProLab.Shared.Common.Response;

namespace ProLab.Shared.Couriers.Response;

public class GetCourierListResponse : PagedListResponse<GetCourierListResponse.ItemData>
{
    public class ItemData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
