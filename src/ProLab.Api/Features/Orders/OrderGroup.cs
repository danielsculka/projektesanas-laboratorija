using FastEndpoints;
using FastEndpoints.Swagger;

namespace ProLab.Api.Features.Orders;

public class OrderGroup : Group
{
    public OrderGroup()
    {
        Configure("orders", ep =>
        {
            ep.AllowAnonymous();
            ep.Description(d => d.AutoTagOverride("Orders"));
        });
    }
}
