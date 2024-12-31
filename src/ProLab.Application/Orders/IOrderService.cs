using FluentResults;
using ProLab.Application.Common.Query;
using ProLab.Application.Orders.Commands;
using ProLab.Application.Orders.Results;
using ProLab.Domain.Orders;

namespace ProLab.Application.Orders;

public interface IOrderService
{
    /// <summary>
    /// Create a order.
    /// </summary>
    /// <param name="command">Order creation data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Created order ID.</returns>
    Task<Result<int>> CreateAsync(CreateOrderCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Delete a order.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Get a list of orders.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result<OrderListResult>> GetAsync(QueryParameters<Order> parameters, CancellationToken cancellationToken);

    /// <summary>
    /// Get a order by ID.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result<OrderResult>> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Update a order.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <param name="command">Order update data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result> UpdateAsync(int id, UpdateOrderCommand command, CancellationToken cancellationToken);
}
