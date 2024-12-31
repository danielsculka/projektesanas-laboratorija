using ProLab.Application.Addresses.Models;

namespace ProLab.Application.Warehouses.Commands;

public class UpdateWarehouseCommand
{
    public string Name { get; set; }
    public AddressData Address { get; set; }
}
