using FluentResults;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;
using ProLab.Application.OpenRoute;
using ProLab.Application.OpenRoute.Results;
using ProLab.Infrastructure.OpenRoute.Models;

namespace ProLab.Infrastructure.OpenRoute;

public class OpenRouteService : IOpenRouteService
{
    private readonly IOpenRouteClient _client;
    private readonly ILogger<OpenRouteService> _logger;

    public OpenRouteService(IOpenRouteClient client, ILogger<OpenRouteService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<Result<OpenRouteDirectionsResult>> GetDirectionsAsync(Point from, Point to, CancellationToken cancellationToken)
    {
        // TODO: add logging

        var request = new OpenRouteDirectionsRequest
        {
            Coordinates = [
                [from.X, from.Y],
                [to.X, to.Y]
                ],
            Units = OpenRouteDirectionsUnits.Kilometers
        };

        Result<OpenRouteDirectionsResponse> response = await _client.GetDirectionsAsync(request, cancellationToken);

        if (response.IsFailed)
            return Result.Fail(response.Errors);

        OpenRouteDirectionsResponse.RouteData? route = response.Value.Routes.FirstOrDefault();

        if (route == null)
            return Result.Fail(OpenRouteErrors.Fetch);

        return new OpenRouteDirectionsResult
        {
            Distance = route.Summary.Distance,
            Duration = route.Summary.Duration
        };
    }
}
