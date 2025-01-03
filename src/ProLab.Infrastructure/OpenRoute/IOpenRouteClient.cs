using FluentResults;
using ProLab.Infrastructure.OpenRoute.Models;

namespace ProLab.Infrastructure.OpenRoute;

public interface IOpenRouteClient
{
    Task<Result<OpenRouteDirectionsResponse>> GetDirectionsAsync(OpenRouteDirectionsRequest requestContent, CancellationToken cancellationToken);
}
