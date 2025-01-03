using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Orders;
using ProLab.Shared.Orders.Requests;

namespace ProLab.Api.Features.Orders.Endpoints;

public class CreateOrderEndpoint : Endpoint<CreateOrderRequest, int>
{
    private readonly IOrderService _orderService;

    public CreateOrderEndpoint(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public override void Configure()
    {
        Post("/");
        Group<OrderGroup>();
    }

    public override async Task HandleAsync(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        Result<int> result = await _orderService.CreateAsync(request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
