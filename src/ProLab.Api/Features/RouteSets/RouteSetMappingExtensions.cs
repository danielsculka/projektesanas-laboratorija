using ProLab.Application.RouteSets.Commands;
using ProLab.Shared.RouteSets;

namespace ProLab.Api.Features.RouteSets;

internal static class RouteSetMappingExtensions
{
    public static GenerateRouteSetCommand ToCommand(this GenerateRouteSetRequest request)
    {
        return new GenerateRouteSetCommand
        {
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
    }
}
