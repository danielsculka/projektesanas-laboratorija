using FastEndpoints;

namespace ProLab.Api.Features.Warehouses;

public class WarehouseGroup : Group
{
    public WarehouseGroup()
    {
        Configure("warehouses", ep =>
        {
            ep.AllowAnonymous();
            ep.Description(d => d.WithTags("Warehouses"));
        });
    }
}
