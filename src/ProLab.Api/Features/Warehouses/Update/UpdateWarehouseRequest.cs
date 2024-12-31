using ProLab.Application.Addresses.Models;

namespace ProLab.Api.Features.Warehouses.Update;

public class UpdateWarehouseRequest
{
    public string Name { get; set; }
    public AddressData Address { get; set; }
}
