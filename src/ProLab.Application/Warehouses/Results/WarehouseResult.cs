using ProLab.Application.Addresses.Models;

namespace ProLab.Application.Warehouses.Results;

public class WarehouseResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AddressData Address { get; set; }
}
