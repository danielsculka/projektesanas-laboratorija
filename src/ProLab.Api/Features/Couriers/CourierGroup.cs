using FastEndpoints;

namespace ProLab.Api.Features.Couriers;

public class CourierGroup : Group
{
    public CourierGroup()
    {
        Configure("couriers", ep =>
        {
            ep.AllowAnonymous();
            ep.Description(d => d.WithTags("Couriers"));
        });
    }
}
