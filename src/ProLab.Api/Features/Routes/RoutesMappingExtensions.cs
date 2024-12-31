using ProLab.Api.Features.Routes.Generate;
using ProLab.Application.Routes.Commands;

namespace ProLab.Api.Features.Routes;

internal static class RoutesMappingExtensions
{
    public static GenerateRouteSetCommand ToCommand(this GenerateRouteSetRequest request)
    {
        return new GenerateRouteSetCommand
        {
        };
    }
}
