using ProLab.App.Extensions;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;
using System.Net.Http.Json;

namespace ProLab.App.Features.Couriers;

public class CourierService : ICourierService
{
    private readonly HttpClient _httpClient;

    private const string c_baseUrl = "api/couriers";

    public CourierService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> CreateAsync(CreateCourierRequest request)
    {
        HttpResponseMessage result = await _httpClient.PostAsJsonAsync(c_baseUrl, request);

        return await result.Content.ReadFromJsonAsync<int>();
    }

    public async Task DeleteAsync(int id)
    {
        string url = $"{c_baseUrl}/{id}";

        _ = await _httpClient.DeleteAsync(url);
    }

    public async Task<GetCourierResponse> GetByIdAsync(int id)
    {
        string url = $"{c_baseUrl}/{id}";

        return await _httpClient.GetFromJsonAsync<GetCourierResponse>(url);
    }

    public async Task<GetCourierListResponse> GetListAsync(GetCourierListRequest? request = null)
    {
        string url = c_baseUrl.ApplyQuery(request);

        return await _httpClient.GetFromJsonAsync<GetCourierListResponse>(url);
    }

    public async Task UpdateAsync(int id, UpdateCourierRequest request)
    {
        string url = $"{c_baseUrl}/{id}";

        _ = await _httpClient.PutAsJsonAsync(url, request);
    }
}
