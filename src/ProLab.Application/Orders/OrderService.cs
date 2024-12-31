using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProLab.Application.Common.Query;
using ProLab.Application.Extensions;
using ProLab.Application.Orders.Commands;
using ProLab.Application.Orders.Results;
using ProLab.Domain.Orders;

namespace ProLab.Application.Orders;

public class OrderService : IOrderService
{
    private readonly IAppDbContext _db;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IAppDbContext db, ILogger<OrderService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<Result<int>> CreateAsync(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Creating a new order.");

        Order entity = command.ToEntity(new Order());

        _ = _db.Orders.Add(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created a new order with ID: {id}", entity.Id);

        return entity.Id;
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Deleting order with ID: {id}", id);

        Order? entity = await _db.Orders.FindAsync([id], cancellationToken);

        if (entity == null)
            return Result.Fail(OrderErrors.NotFound);

        _ = _db.Orders.Remove(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Deleted order with ID: {id}.", id);

        return Result.Ok();
    }

    public async Task<Result<OrderListResult>> GetAsync(QueryParameters<Order> parameters, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Retrieving orders.");

        IQueryable<Order> query = _db.Orders
            .AsNoTracking()
            .ApplyFilter(parameters.Filter);

        int totalCount = await query.CountAsync(cancellationToken);

        OrderListResult.ItemData[] items = await query
            .ApplySorting(parameters.Sorting)
            .ApplyPaging(parameters.Paging)
            .Select(OrderMapper.ProjectList())
            .ToArrayAsync(cancellationToken);

        _logger.LogInformation("Retrieved {count} orders.", items.Length);

        return new OrderListResult(
            items,
            totalCount,
            parameters.Paging?.PageSize,
            parameters.Paging?.CurrentPage
            );
    }

    public async Task<Result<OrderResult>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Retrieving order with ID: {id}", id);

        OrderResult? result = await _db.Orders
            .AsNoTracking()
            .Where(order => order.Id == id)
            .Select(OrderMapper.Project())
            .FirstOrDefaultAsync(cancellationToken);

        if (result == null)
            return Result.Fail(OrderErrors.NotFound);

        _logger.LogInformation("Retrieved order with ID: {id}.", id);

        return result;
    }

    public async Task<Result> UpdateAsync(int id, UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Updating order with ID: {id}", id);

        Order? entity = await _db.Orders.FindAsync([id], cancellationToken);

        if (entity == null)
            return Result.Fail(OrderErrors.NotFound);

        _ = command.ToEntity(entity);

        _ = await _db.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Updated order with ID: {id}.", id);

        return Result.Ok();
    }
}
