using FluentResults;
using ProLab.Application.RouteSets.Commands;

namespace ProLab.Application.RouteSets;

public interface IRouteSetService
{
    /// <summary>
    /// Generate a route set.
    /// </summary>
    /// <param name="command">Route set generation data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result> GenerateAsync(GenerateRouteSetCommand command, CancellationToken cancellationToken);
}
