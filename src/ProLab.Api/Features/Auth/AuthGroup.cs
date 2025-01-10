using FastEndpoints;
using FastEndpoints.Swagger;

namespace ProLab.Api.Features.Orders;

public class AuthGroup : Group
{
    public AuthGroup()
    {
        Configure("auth", ep =>
        {
            ep.AllowAnonymous();
            ep.Description(d => d.AutoTagOverride("auth"));
        });
    }
}
