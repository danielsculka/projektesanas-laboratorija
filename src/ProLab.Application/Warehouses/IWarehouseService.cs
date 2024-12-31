using FluentResults;
using ProLab.Application.Common.Query;
using ProLab.Application.Warehouses.Commands;
using ProLab.Application.Warehouses.Results;
using ProLab.Domain.Warehouses;

namespace ProLab.Application.Warehouses;

public interface IWarehouseService
{
    /// <summary>
    /// Create a order.
    /// </summary>
    /// <param name="command">Order creation data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Created warehouse ID.</returns>
    Task<Result<int>> CreateAsync(CreateWarehouseCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Delete a warehouse.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Get a list of warehouses.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result<WarehouseListResult>> GetAsync(QueryParameters<Warehouse> parameters, CancellationToken cancellationToken);

    /// <summary>
    /// Get a warehouse by ID.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result<WarehouseResult>> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Update a warehouse.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <param name="command">Order update data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result> UpdateAsync(int id, UpdateWarehouseCommand command, CancellationToken cancellationToken);
}
