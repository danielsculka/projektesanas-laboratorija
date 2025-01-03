using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Orders;

namespace ProLab.Api.Features.Orders.Endpoints;

public class DeleteOrderEndpoint : EndpointWithoutRequest
{
    private readonly IOrderService _orderService;

    public DeleteOrderEndpoint(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public override void Configure()
    {
        Delete("/{id}");
        Group<OrderGroup>();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        int orderId = Route<int>("id");

        Result result = await _orderService.DeleteAsync(orderId, cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
