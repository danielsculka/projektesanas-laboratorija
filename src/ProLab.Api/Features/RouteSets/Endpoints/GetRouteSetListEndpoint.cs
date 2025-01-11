using FastEndpoints;
using FluentResults;
using ProLab.Api.Extensions;
using ProLab.Application.RouteSets;
using ProLab.Application.RouteSets.Results;
using ProLab.Shared.RouteSets.Requests;
using ProLab.Shared.RouteSets.Response;

namespace ProLab.Api.Features.RouteSets.Endpoints;

public class GetRouteSetListEndpoint : Endpoint<GetRouteSetListRequest, GetRouteSetListResponse>
{
    private readonly IRouteSetService _routeSetService;

    public GetRouteSetListEndpoint(IRouteSetService routeSetService)
    {
        _routeSetService = routeSetService;
    }

    public override void Configure()
    {
        Get("/");
        Group<RouteSetGroup>();
    }

    public override async Task HandleAsync(GetRouteSetListRequest request, CancellationToken cancellationToken)
    {
        Result<RouteSetListResult> result = await _routeSetService
            .GetAsync(request.ToQueryParameters(), cancellationToken);

        await this.SendResultAsync(result, result => result.ToResponse(), cancellationToken);
    }
}
