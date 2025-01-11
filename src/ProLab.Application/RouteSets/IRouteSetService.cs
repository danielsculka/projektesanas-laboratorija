using FluentResults;
using ProLab.Application.Common.Query;
using ProLab.Application.RouteSets.Commands;
using ProLab.Application.RouteSets.Results;
using ProLab.Domain.Routes;

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

    /// <summary>
    /// Get a list of route sets.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result<RouteSetListResult>> GetAsync(QueryParameters<RouteSet> parameters, CancellationToken cancellationToken);

}
