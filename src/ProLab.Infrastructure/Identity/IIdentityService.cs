namespace ProLab.Infrastructure.Identity;

public interface IIdentityService
{
    ///// <summary>
    ///// Get user logins.
    ///// </summary>
    ///// <returns></returns>
    //SetQuery<IdentityUserLogin> GetLogins();
    ///// <summary>
    ///// Get users.
    ///// </summary>
    ///// <returns>User query.</returns>
    //SetQuery<User> GetUsers();
    ///// <summary>
    ///// Create a user.
    ///// </summary>
    ///// <param name="item">User data</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>New user ID</returns>
    //Task<Guid> CreateAsync(UserCreateCommand item, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Update a user.
    ///// </summary>
    ///// <param name="userId">User ID</param>
    ///// <param name="item">User data</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns></returns>
    //Task UpdateAsync(Guid userId, UserUpdateCommand item, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Add user refresh token.
    ///// </summary>
    ///// <param name="loginId">User login ID</param>
    ///// <param name="token">Refresh token value</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns></returns>
    //Task AddRefreshTokenAsync(Guid loginId, string token, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Remove user refresh token.
    ///// </summary>
    ///// <param name="token">Refresh token value</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns></returns>
    //Task RemoveRefreshTokenAsync(string token, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Mark a user to reset his password.
    ///// </summary>
    ///// <param name="username">User name</param>
    ///// <param name="force">If set to true, current user password is removed and user is forced to reset his password using a secret URL.
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// Otherwise, user must reset his password after next successfull login.</param>
    ///// <returns></returns>
    //Task<string> MustResetPasswordAsync(string username, bool force = false, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Recover user login password.
    ///// </summary>
    ///// <param name="userName">User name of the user login for which to recover password.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns></returns>
    //Task RecoverPasswordAsync(string userName, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Reset user password.
    ///// </summary>
    ///// <param name="id">User login ID.</param>
    ///// <param name="password">New password</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns></returns>
    //Task<Guid> ResetPasswordAsync(Guid id, string password, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Reset user password.
    ///// </summary>
    ///// <param name="secret">Secret key</param>
    ///// <param name="password">New password</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns></returns>
    //Task<Guid> ResetPasswordAsync(string secret, string password, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Change user password.
    ///// </summary>
    ///// <param name="username">User name</param>
    ///// <param name="password">New password</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns></returns>
    //Task ChangePassword(string username, string password, CancellationToken cancellationToken = default);
    ///// <summary>
    ///// Verify user password is valid.
    ///// </summary>
    ///// <param name="username">User name</param>
    ///// <param name="password">User password</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Verification result.</returns>
    //Task<VerifyPasswordResult> VerifyPasswordAsync(string username, string password, CancellationToken cancellationToken = default);
}
