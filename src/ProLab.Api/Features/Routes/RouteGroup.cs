using FastEndpoints;

namespace ProLab.Api.Features.Routes;

public class RouteGroup : Group
{
    public RouteGroup()
    {
        Configure("routes", ep =>
        {
            ep.AllowAnonymous();
            ep.Description(d => d.WithTags("Routes"));
        });
    }
}
