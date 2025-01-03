using ProLab.Shared.Common;

namespace ProLab.Shared.Warehouses.Requests;

public class UpdateWarehouseRequest
{
    public string Name { get; set; }
    public AddressData Address { get; set; }
}
