using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Orders;
using ProLab.Shared.Orders.Requests;

namespace ProLab.Api.Features.Orders.Endpoints;

public class UpdateOrderEndpoint : Endpoint<UpdateOrderRequest>
{
    private readonly IOrderService _orderService;

    public UpdateOrderEndpoint(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public override void Configure()
    {
        Put("/{id}");
        Group<OrderGroup>();
    }

    public override async Task HandleAsync(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        int orderId = Route<int>("id");

        Result result = await _orderService.UpdateAsync(orderId, request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
