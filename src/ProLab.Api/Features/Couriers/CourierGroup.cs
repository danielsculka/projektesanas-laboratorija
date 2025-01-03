using FastEndpoints;
using FastEndpoints.Swagger;

namespace ProLab.Api.Features.Couriers;

public class CourierGroup : Group
{
    public CourierGroup()
    {
        Configure("couriers", ep =>
        {
            ep.AllowAnonymous();
            ep.Description(d => d.AutoTagOverride("Couriers"));
        });
    }
}
