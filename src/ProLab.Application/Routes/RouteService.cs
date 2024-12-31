using FluentResults;
using Microsoft.Extensions.Logging;
using ProLab.Application.Routes.Commands;

namespace ProLab.Application.Routes;

public class RouteService : IRouteService
{
    private readonly IAppDbContext _db;
    private readonly ILogger<RouteService> _logger;

    public RouteService(IAppDbContext db, ILogger<RouteService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public Task<Result> GenerateSetAsync(GenerateRouteSetCommand command, CancellationToken cancellationToken) => throw new NotImplementedException();
}
