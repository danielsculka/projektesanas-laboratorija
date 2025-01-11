using ProLab.Shared.Common;

namespace ProLab.Shared.Orders.Response;

public class GetOrderResponse
{
    public int Id { get; set; }
    public required string Number { get; set; }
    public required AddressData Address { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int WarehouseId { get; set; }
}
