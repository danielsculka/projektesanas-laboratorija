using ProLab.Application.Addresses.Models;

namespace ProLab.Api.Features.Orders.Update;

public class UpdateOrderRequest
{
    public string Number { get; set; }
    public AddressData Address { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int WarehouseId { get; set; }
}
