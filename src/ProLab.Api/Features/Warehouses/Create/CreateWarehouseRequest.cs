using ProLab.Application.Addresses.Models;

namespace ProLab.Api.Features.Warehouses.Create;

public class CreateWarehouseRequest
{
    public string Name { get; set; }
    public AddressData Address { get; set; }
}
