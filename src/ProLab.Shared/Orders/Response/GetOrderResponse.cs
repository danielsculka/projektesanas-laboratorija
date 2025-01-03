using ProLab.Shared.Common;

namespace ProLab.Shared.Orders.Response;

public class GetOrderResponse
{
    public int Id { get; set; }
    public string Number { get; set; }
    public AddressData Address { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
