using FluentResults;
using ProLab.Application.Routes.Commands;

namespace ProLab.Application.Routes;

public interface IRouteService
{
    /// <summary>
    /// Generate a route set.
    /// </summary>
    /// <param name="command">Route set generation data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result> GenerateSetAsync(GenerateRouteSetCommand command, CancellationToken cancellationToken);
}
