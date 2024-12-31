using ProLab.Application.Common.Errors;

namespace ProLab.Application.Warehouses;

public static class WarehouseErrors
{

    public static readonly Error NotFound = new("Warehouses.NotFound", $"Warehouse not found.", ErrorType.NotFound);

    public static readonly Error AlreadyExists = new("Warehouses.AlreadyExists", "Warehouse already exists.", ErrorType.Conflict);
}
