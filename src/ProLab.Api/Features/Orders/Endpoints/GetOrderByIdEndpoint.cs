using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Orders;
using ProLab.Application.Orders.Results;
using ProLab.Shared.Orders.Response;

namespace ProLab.Api.Features.Orders.Endpoints;

public class GetOrderByIdEndpoint : EndpointWithoutRequest<GetOrderResponse>
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

        await this.SendResultAsync(result, result => result.ToResponse(), cancellationToken);
    }
}
