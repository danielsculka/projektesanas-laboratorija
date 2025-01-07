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
}
