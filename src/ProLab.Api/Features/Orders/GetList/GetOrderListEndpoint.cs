using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Orders;
using ProLab.Application.Orders.Results;

namespace ProLab.Api.Features.Orders.GetList;

public class GetOrderListEndpoint : Endpoint<GetOrderListRequest, OrderListResult>
{
    private readonly IOrderService _orderService;

    public GetOrderListEndpoint(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public override void Configure()
    {
        Get("/");
        Group<OrderGroup>();
    }

    public override async Task HandleAsync(GetOrderListRequest request, CancellationToken cancellationToken)
    {
        Result<OrderListResult> result = await _orderService
            .GetAsync(request.ToQueryParameters(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
