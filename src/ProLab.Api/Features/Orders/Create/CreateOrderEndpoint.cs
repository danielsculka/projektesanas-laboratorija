using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Orders;

namespace ProLab.Api.Features.Orders.Create;

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
