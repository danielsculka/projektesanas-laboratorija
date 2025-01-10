using ProLab.Shared.RouteSets;

namespace ProLab.App.Features.RouteSets;

public interface IRouteSetService
{
    Task GenerateAsync(GenerateRouteSetRequest request);
}
