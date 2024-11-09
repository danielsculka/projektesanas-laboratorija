namespace ProLab.Application.Warehouses;

public class WarehouseService
{
    private readonly IAppDbContext _db;
    private readonly IWarehouseService _warehouseService;

    public WarehouseService(IAppDbContext db, IWarehouseService warehouseService)
    {
        _db = db;
        _warehouseService = warehouseService;
    }
}
