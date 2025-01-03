using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.RouteSets;
using ProLab.Shared.RouteSets;

namespace ProLab.Api.Features.RouteSets.Endpoints;

public class GenerateRouteSetEndpoint : Endpoint<GenerateRouteSetRequest>
{
    private readonly IRouteSetService _routeService;

    public GenerateRouteSetEndpoint(IRouteSetService routeService)
    {
        _routeService = routeService;
    }

    public override void Configure()
    {
        Post("/generate");
        Group<RouteSetGroup>();
    }

    public override async Task HandleAsync(GenerateRouteSetRequest request, CancellationToken cancellationToken)
    {
        Result result = await _routeService.GenerateAsync(request.ToCommand(), cancellationToken);

        await this.SendResultAsync(result, cancellationToken);
    }
}
