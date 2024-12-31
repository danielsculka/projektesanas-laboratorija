using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Orders;
using ProLab.Application.Orders.Results;

namespace ProLab.Api.Features.Orders.GetById;

public class GetOrderByIdEndpoint : EndpointWithoutRequest<OrderResult>
{
    private readonly IOrderService _orderService;

    public GetOrderByIdEndpoint(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public override void Configure()
    {
        Get("/{id}");
        Group<OrderGroup>();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        int orderId = Route<int>("id");

        Result<OrderResult> result = await _orderService.GetByIdAsync(orderId, cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
