using ProLab.App.Extensions;
using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;
using System.Net.Http.Json;

namespace ProLab.App.Features.Couriers;

public class CourierService : ICourierService
{
    private readonly HttpClient _httpClient;

    private const string c_baseUr = "api/couriers";

    public CourierService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetCourierListResponse?> GetListAsync(GetCourierListRequest? request = null)
    {
        try
        {
            string url = c_baseUr.ApplyQuery(request);

            return await _httpClient.GetFromJsonAsync<GetCourierListResponse>(url);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> CreateAsync(CreateCourierRequest request)
    {
        try
        {
            string url = c_baseUr;

            var result = await _httpClient.PostAsJsonAsync(url, request);

            return await result.Content.ReadFromJsonAsync<int>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> UpdateAsync(int id, UpdateCourierRequest request)
    {
        try
        {
            string url = $"{c_baseUr}/{id}";

            var result = await _httpClient.PutAsJsonAsync(url, request);

            return await result.Content.ReadFromJsonAsync<int>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            string url = $"{c_baseUr}/{id}";

            var result = await _httpClient.DeleteAsync(url);

            return await result.Content.ReadFromJsonAsync<int>();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
