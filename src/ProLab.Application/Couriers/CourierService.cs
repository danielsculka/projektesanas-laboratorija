using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProLab.Application.Common.Query;
using ProLab.Application.Couriers.Commands;
using ProLab.Application.Couriers.Results;
using ProLab.Application.Extensions;
using ProLab.Domain.Couriers;

namespace ProLab.Application.Couriers;

public class CourierService : ICourierService
{
    private readonly IAppDbContext _db;
    private readonly ILogger<CourierService> _logger;

    public CourierService(IAppDbContext db, ILogger<CourierService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<Result<int>> CreateAsync(CreateCourierCommand command, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Creating a new courier.");

        Courier entity = command.ToEntity(new Courier());

        _ = _db.Couriers.Add(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created a new courier with ID: {id}", entity.Id);

        return entity.Id;
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Deleting courier with ID: {id}", id);

        Courier? entity = await _db.Couriers.FindAsync([id], cancellationToken);

        if (entity == null)
            return Result.Fail(CourierErrors.NotFound);

        _ = _db.Couriers.Remove(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Deleted courier with ID: {id}.", id);

        return Result.Ok();
    }

    public async Task<Result<CourierListResult>> GetAsync(QueryParameters<Courier> parameters, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Retrieving couriers.");

        IQueryable<Courier> query = _db.Couriers
            .AsNoTracking()
            .ApplyFilter(parameters.Filter);

        int totalCount = await query.CountAsync(cancellationToken);

        CourierListResult.ItemData[] items = await query
            .ApplySorting(parameters.Sorting)
            .ApplyPaging(parameters.Paging)
            .Select(CourierMapper.ProjectList())
            .ToArrayAsync(cancellationToken);

        _logger.LogInformation("Retrieved {count} couriers.", items.Length);

        return new CourierListResult(
            items,
            totalCount,
            parameters.Paging?.PageSize,
            parameters.Paging?.CurrentPage
            );
    }

    public async Task<Result<CourierResult>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Retrieving courier with ID: {id}", id);

        CourierResult? result = await _db.Couriers
            .AsNoTracking()
            .Where(courier => courier.Id == id)
            .Select(CourierMapper.Project())
            .FirstOrDefaultAsync(cancellationToken);

        if (result == null)
            return Result.Fail(CourierErrors.NotFound);

        _logger.LogInformation("Retrieved courier with ID: {id}.", id);

        return result;
    }

    public async Task<Result> UpdateAsync(int id, UpdateCourierCommand command, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Updating courier with ID: {id}", id);

        Courier? entity = await _db.Couriers.FindAsync([id], cancellationToken);

        if (entity == null)
            return Result.Fail(CourierErrors.NotFound);

        _ = command.ToEntity(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Updated courier with ID: {id}.", id);

        return Result.Ok();
    }
}
