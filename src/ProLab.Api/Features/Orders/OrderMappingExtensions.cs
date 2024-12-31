using ProLab.Api.Features.Orders.Create;
using ProLab.Api.Features.Orders.GetList;
using ProLab.Api.Features.Orders.Update;
using ProLab.Application.Common.Query;
using ProLab.Application.Orders.Commands;
using ProLab.Domain.Orders;

namespace ProLab.Api.Features.Orders;

internal static class OrderMappingExtensions
{
    public static CreateOrderCommand ToCommand(this CreateOrderRequest request)
    {
        return new CreateOrderCommand
        {
            Number = request.Number,
            Address = request.Address,
            WarehouseId = request.WarehouseId
        };
    }

    public static UpdateOrderCommand ToCommand(this UpdateOrderRequest request)
    {
        return new UpdateOrderCommand
        {
            Number = request.Number,
            Address = request.Address,
            WarehouseId = request.WarehouseId
        };
    }

    public static QueryParameters<Order> ToQueryParameters(this GetOrderListRequest request)
    {
        return new QueryParameters<Order>
        {
            Filter = request.Filter,
            Sorting = request.Sorting,
            Paging = request.Paging
        };
    }
}
