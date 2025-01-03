using ProLab.Shared.Common;

namespace ProLab.Shared.Warehouses.Requests;

public class CreateWarehouseRequest
{
    public string Name { get; set; }
    public AddressData Address { get; set; }
}
