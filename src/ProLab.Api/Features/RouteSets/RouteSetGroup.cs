using FastEndpoints;

namespace ProLab.Api.Features.RouteSets;

public class RouteSetGroup : Group
{
    public RouteSetGroup()
    {
        Configure("routeSets", ep =>
        {
            ep.AllowAnonymous();
            ep.Description(d => d.WithTags("RouteSets"));
        });
    }
}
