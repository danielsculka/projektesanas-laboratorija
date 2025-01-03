using ProLab.Shared.Common;

namespace ProLab.Shared.Warehouses.Response;

public class GetWarehouseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AddressData Address { get; set; }
}
