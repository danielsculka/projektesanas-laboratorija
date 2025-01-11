using ProLab.App.Extensions;
using ProLab.Shared.Orders.Requests;
using ProLab.Shared.Orders.Response;
using System.Net.Http.Json;

namespace ProLab.App.Features.Orders;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    private const string c_baseUrl = "api/orders";

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> CreateAsync(CreateOrderRequest request)
    {
        HttpResponseMessage result = await _httpClient.PostAsJsonAsync(c_baseUrl, request);

        return await result.Content.ReadFromJsonAsync<int>();
    }

    public async Task DeleteAsync(int id)
    {
        string url = $"{c_baseUrl}/{id}";

        _ = await _httpClient.DeleteAsync(url);
    }

    public async Task<GetOrderResponse> GetByIdAsync(int id)
    {
        string url = $"{c_baseUrl}/{id}";

        return await _httpClient.GetFromJsonAsync<GetOrderResponse>(url);
    }

    public async Task<GetOrderListResponse> GetListAsync(GetOrderListRequest? request = null)
    {
        string url = c_baseUrl.ApplyQuery(request);

        return await _httpClient.GetFromJsonAsync<GetOrderListResponse>(url);
    }

    public async Task UpdateAsync(int id, UpdateOrderRequest request)
    {
        string url = $"{c_baseUrl}/{id}";

        _ = await _httpClient.PutAsJsonAsync(url, request);
    }
}
