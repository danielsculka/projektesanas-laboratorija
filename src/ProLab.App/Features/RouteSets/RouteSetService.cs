using ProLab.App.Extensions;
using ProLab.Shared.RouteSets.Requests;
using ProLab.Shared.RouteSets.Response;
using System.Net.Http.Json;

namespace ProLab.App.Features.RouteSets;

public class RouteSetService : IRouteSetService
{
    private readonly HttpClient _httpClient;

    private const string c_baseUrl = "api/routeSets";

    public RouteSetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task GenerateAsync(GenerateRouteSetRequest request)
    {
        string url = $"{c_baseUrl}/generate";

        _ = await _httpClient.PostAsJsonAsync(url, request);
    }

    public async Task<GetRouteSetListResponse> GetListAsync(GetRouteSetListRequest? request = null)
    {
        string url = c_baseUrl.ApplyQuery(request);

        return await _httpClient.GetFromJsonAsync<GetRouteSetListResponse>(url);
    }
}
