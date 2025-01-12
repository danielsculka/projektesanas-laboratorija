using FluentResults;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;
using PolylinerNet;
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
        await Task.Delay(1500, cancellationToken);

        var request = new OpenRouteDirectionsRequest
        {
            Coordinates = [
                [from.X, from.Y],
                [to.X, to.Y]
                ]
        };

        Result<OpenRouteDirectionsResponse> response = await _client.GetDirectionsAsync(request, cancellationToken);

        if (response.IsFailed)
            return Result.Fail(response.Errors);

        OpenRouteDirectionsResponse.RouteData? route = response.Value.Routes.FirstOrDefault();

        if (route == null)
            return Result.Fail(OpenRouteErrors.Fetch);

        var polyliner = new Polyliner();

        IEnumerable<Coordinate> coordinates = polyliner
            .Decode(route.Geometry)
            .Select(point => new Coordinate(point.Longitude, point.Latitude));

        var geometryFactory = new GeometryFactory();

        LineString lineString = geometryFactory.CreateLineString(coordinates.ToArray());

        lineString.SRID = 4326;

        return new OpenRouteDirectionsResult
        {
            Distance = route.Summary.Distance,
            Duration = route.Summary.Duration,
            Path = lineString
        };
    }
}
