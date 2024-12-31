using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.Routes;

namespace ProLab.Api.Features.Routes.Generate;

public class GenerateRouteSetEndpoint : Endpoint<GenerateRouteSetRequest>
{
    private readonly IRouteService _routeService;

    public GenerateRouteSetEndpoint(IRouteService routeService)
    {
        _routeService = routeService;
    }

    public override void Configure()
    {
        Post("/generateSet");
        Group<RouteGroup>();
    }

    public override async Task HandleAsync(GenerateRouteSetRequest request, CancellationToken cancellationToken)
    {
        Result result = await _routeService.GenerateSetAsync(request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
