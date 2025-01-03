using FastEndpoints;
using FastEndpoints.Swagger;

namespace ProLab.Api.Features.RouteSets;

public class RouteSetGroup : Group
{
    public RouteSetGroup()
    {
        Configure("routeSets", ep =>
        {
            ep.AllowAnonymous();
            ep.Description(d => d.AutoTagOverride("Route sets"));
        });
    }
}
