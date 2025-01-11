using ProLab.Shared.RouteSets.Requests;
using ProLab.Shared.RouteSets.Response;

namespace ProLab.App.Features.RouteSets;

public interface IRouteSetService
{
    Task GenerateAsync(GenerateRouteSetRequest request);

    Task<GetRouteSetListResponse> GetListAsync(GetRouteSetListRequest? request = null);
}
