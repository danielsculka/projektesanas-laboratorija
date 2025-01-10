using ProLab.Application.Addresses.Models;

namespace ProLab.Application.Orders.Commands;

public class UpdateOrderCommand
{
    public required string Number { get; set; }
    public required AddressData Address { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int WarehouseId { get; set; }
}
