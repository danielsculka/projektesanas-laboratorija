using ProLab.Shared.Common;

namespace ProLab.Shared.Orders.Requests;

public class CreateOrderRequest
{
    public string Number { get; set; }
    public AddressData Address { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int WarehouseId { get; set; }
}
