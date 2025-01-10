using ProLab.Shared.Orders.Requests;
using ProLab.Shared.Orders.Response;

namespace ProLab.App.Features.Orders;

public interface IOrderService
{
    Task<int> CreateAsync(CreateOrderRequest request);

    Task DeleteAsync(int id);

    Task<GetOrderResponse> GetByIdAsync(int id);

    Task<GetOrderListResponse> GetListAsync(GetOrderListRequest? request = null);

    Task UpdateAsync(int id, UpdateOrderRequest request);
}
