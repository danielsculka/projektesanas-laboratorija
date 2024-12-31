using FluentResults;
using ProLab.Application.Common.Query;
using ProLab.Application.Couriers.Commands;
using ProLab.Application.Couriers.Results;
using ProLab.Domain.Couriers;

namespace ProLab.Application.Couriers;

public interface ICourierService
{
    /// <summary>
    /// Create a courier.
    /// </summary>
    /// <param name="command">Courier creation data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Created courier ID.</returns>
    Task<Result<int>> CreateAsync(CreateCourierCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Delete a courier.
    /// </summary>
    /// <param name="id">Courier ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Get couriers list.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result<CourierListResult>> GetAsync(QueryParameters<Courier> parameters, CancellationToken cancellationToken);

    /// <summary>
    /// Get a courier by ID.
    /// </summary>
    /// <param name="id">Courier ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result<CourierResult>> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Update a courier.
    /// </summary>
    /// <param name="id">Courier ID.</param>
    /// <param name="command">Courier update data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Result> UpdateAsync(int id, UpdateCourierCommand command, CancellationToken cancellationToken);
}
