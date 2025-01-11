using ProLab.App.Extensions;
using ProLab.Shared.Warehouses.Requests;
using ProLab.Shared.Warehouses.Response;
using System.Net.Http.Json;

namespace ProLab.App.Features.Warehouses;

public class WarehouseService : IWarehouseService
{
    private readonly HttpClient _httpClient;

    private const string c_baseUrl = "api/warehouses";

    public WarehouseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> CreateAsync(CreateWarehouseRequest request)
    {
        HttpResponseMessage result = await _httpClient.PostAsJsonAsync(c_baseUrl, request);

        return await result.Content.ReadFromJsonAsync<int>();
    }

    public async Task DeleteAsync(int id)
    {
        string url = $"{c_baseUrl}/{id}";

        _ = await _httpClient.DeleteAsync(url);
    }

    public async Task<GetWarehouseResponse> GetByIdAsync(int id)
    {
        string url = $"{c_baseUrl}/{id}";

        return await _httpClient.GetFromJsonAsync<GetWarehouseResponse>(url);
    }

    public async Task<GetWarehouseListResponse> GetListAsync(GetWarehouseListRequest? request = null)
    {
        string url = c_baseUrl.ApplyQuery(request);

        return await _httpClient.GetFromJsonAsync<GetWarehouseListResponse>(url);
    }

    public async Task UpdateAsync(int id, UpdateWarehouseRequest request)
    {
        string url = $"{c_baseUrl}/{id}";

        _ = await _httpClient.PutAsJsonAsync(url, request);
    }
}
