using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProLab.Application.Common.Query;
using ProLab.Application.Extensions;
using ProLab.Application.Warehouses.Commands;
using ProLab.Application.Warehouses.Results;
using ProLab.Domain.Warehouses;

namespace ProLab.Application.Warehouses;

public class WarehouseService : IWarehouseService
{
    private readonly IAppDbContext _db;
    private readonly ILogger<WarehouseService> _logger;

    public WarehouseService(IAppDbContext db, ILogger<WarehouseService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<Result<int>> CreateAsync(CreateWarehouseCommand command, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Creating a new warehouse.");

        Warehouse entity = command.ToEntity(new Warehouse());

        _ = _db.Warehouses.Add(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created a new warehouse with ID: {id}", entity.Id);

        return entity.Id;
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Deleting warehouse with ID: {id}", id);

        Warehouse? entity = await _db.Warehouses.FindAsync([id], cancellationToken);

        if (entity == null)
            return Result.Fail(WarehouseErrors.NotFound);

        _ = _db.Warehouses.Remove(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Deleted warehouse with ID: {id}.", id);

        return Result.Ok();
    }

    public async Task<Result<WarehouseListResult>> GetAsync(QueryParameters<Warehouse> parameters, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Retrieving warehouses.");

        IQueryable<Warehouse> query = _db.Warehouses
            .AsNoTracking()
            .ApplyFilter(parameters.Filter);

        int totalCount = await query.CountAsync(cancellationToken);

        WarehouseListResult.ItemData[] items = await query
            .ApplySorting(parameters.Sorting)
            .ApplyPaging(parameters.Paging)
            .Select(WarehouseMapper.ProjectList())
            .ToArrayAsync(cancellationToken);

        _logger.LogInformation("Retrieved {count} warehouses.", items.Length);

        return new WarehouseListResult(
            items,
            totalCount,
            parameters.Paging?.PageSize,
            parameters.Paging?.CurrentPage
            );
    }

    public async Task<Result<WarehouseResult>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Retrieving warehouse with ID: {id}", id);

        WarehouseResult? result = await _db.Warehouses
            .AsNoTracking()
            .Where(warehouse => warehouse.Id == id)
            .Select(WarehouseMapper.Project())
            .FirstOrDefaultAsync(cancellationToken);

        if (result == null)
            return Result.Fail(WarehouseErrors.NotFound);

        _logger.LogInformation("Retrieved warehouse with ID: {id}.", id);

        return result;
    }

    public async Task<Result> UpdateAsync(int id, UpdateWarehouseCommand command, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Updating warehouse with ID: {id}", id);

        Warehouse? entity = await _db.Warehouses.FindAsync([id], cancellationToken);

        if (entity == null)
            return Result.Fail(WarehouseErrors.NotFound);

        _ = command.ToEntity(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Updated warehouse with ID: {id}.", id);

        return Result.Ok();
    }
}
