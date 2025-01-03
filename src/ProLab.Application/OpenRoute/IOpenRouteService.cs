using FluentResults;
using NetTopologySuite.Geometries;
using ProLab.Application.OpenRoute.Results;

namespace ProLab.Application.OpenRoute;

public interface IOpenRouteService
{
    Task<Result<OpenRouteDirectionsResult>> GetDirectionsAsync(Point from, Point to, CancellationToken cancellationToken);
}
