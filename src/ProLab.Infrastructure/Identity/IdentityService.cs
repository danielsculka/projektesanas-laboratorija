namespace ProLab.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    //private readonly IIdentityDbContext _db;
    //private readonly IIdentityValidator _validator;
    //private readonly IPasswordValidator _passwordValidator;

    //public IdentityService(
    //    IIdentityDbContext db,
    //    IIdentityValidator validator,
    //    IPasswordValidator passwordValidator)
    //{
    //    _db = db;
    //    _validator = validator;
    //    _passwordValidator = passwordValidator;
    //}

    ///// <inheritdoc/>
    //public async Task AddRefreshTokenAsync(Guid loginId, string token, CancellationToken cancellationToken = default)
    //{
    //    _ = await _db.IdentityRefreshTokens.AddAsync(new IdentityRefreshToken
    //    {
    //        UserLoginId = loginId,
    //        Value = token
    //    }, cancellationToken);

    //    _ = await _db.SaveChangesAsync(cancellationToken);
    //}

    ///// <inheritdoc/>
    ///// <exception cref="EntityNotFoundException"></exception>
    ///// <exception cref="NotSupportedException"></exception>
    //public async Task ChangePassword(string username, string password, CancellationToken cancellationToken = default)
    //{
    //    IdentityUserLogin login = await _db.IdentityUserLogins.FirstOrDefaultAsync(t => t.UserName == username, cancellationToken);

    //    if (login == null)
    //        throw new EntityNotFoundException();

    //    PreventNonFormsPassword(login);
    //    PreventAdminUserUpdates(login);

    //    _ = await SetPassword(login, password);
    //}

    ///// <inheritdoc/>
    ///// <exception cref="ValidationException"></exception>
    ///// <exception cref="EntityAlreadyExistsException"></exception>
    //public async Task<Guid> CreateAsync(UserCreateCommand command, CancellationToken cancellationToken = default)
    //{
    //    _validator.Validate(command);

    //    if (await ExistsAsync(command.UserName, cancellationToken))
    //        throw new EntityAlreadyExistsException(typeof(IdentityUserLogin), $"User with userName:{command.UserName} already exists.")
    //            .WithErrorCode(InfrastructureErrorCode.UserNameAlreadyExists);

    //    if (await ExistsPersonAndRoleCombinationAsync(command.PersonTechnicalId, command.Role, cancellationToken))
    //        throw new InvalidOperationException($"User with person id:{command.PersonTechnicalId}, role:{command.Role} already exists.")
    //            .WithErrorCode(InfrastructureErrorCode.CannotHaveDuplicatesByPersonAndRole);

    //    var id = Guid.NewGuid();

    //    // Multiple logins can be mapped to a single user.
    //    // In order to achieve this, define how to find a correct user.
    //    // Otherwise, each new login creates a new user.

    //    var login = IdentityUserLogin.Create(command.UserName, command.AuthType);

    //    login.User = new User(id, command.UserName, command.Role, command.Type);

    //    login.User.IsDisabled = command.IsDisabled;

    //    login.User.SetPersonTechnicalId(command.PersonTechnicalId);

    //    _ = await _db.IdentityUserLogins.AddAsync(login, cancellationToken);

    //    _ = MustResetPassword(login, false);

    //    _ = await _db.SaveChangesAsync(cancellationToken);

    //    return id;
    //}

    ///// <inheritdoc/>
    //public SetQuery<IdentityUserLogin> GetLogins() => new(_db.IdentityUserLogins.AsNoTracking());

    ///// <inheritdoc/>
    //public SetQuery<User> GetUsers() => new(_db.Users.AsNoTracking());

    ///// <inheritdoc/>
    ///// <exception cref="EntityNotFoundException"></exception>
    ///// <exception cref="NotSupportedException"></exception>
    //public async Task<string> MustResetPasswordAsync(string username, bool force = false, CancellationToken cancellationToken = default)
    //{
    //    IdentityUserLogin login = await _db.IdentityUserLogins
    //        .FirstOrDefaultAsync(t => t.UserName == username, cancellationToken);

    //    if (login == null)
    //        throw new EntityNotFoundException();

    //    string secret = MustResetPassword(login, force);

    //    _ = await _db.SaveChangesAsync(cancellationToken);

    //    return secret;
    //}

    ///// <inheritdoc />
    ///// <exception cref="InvalidOperationException"></exception>
    ///// <exception cref="ValidationException"></exception>
    ///// <exception cref="TemplateEmptyException"></exception>
    //public async Task RecoverPasswordAsync(string userName, CancellationToken cancellationToken = default)
    //{
    //    IdentityUserLogin[] userLogins = await _db.IdentityUserLogins
    //        .Where(t => t.UserName == userName && t.AuthType == UserAuthType.Forms)
    //            .Include(userLogin => userLogin.User)
    //                .ThenInclude(user => user.PersonTechnical)
    //                    .ThenInclude(user => user.Person)
    //        .ToArrayAsync(cancellationToken);

    //    if (userLogins.Length == 0)
    //        throw new InvalidOperationException($"User logins not found for user name:{userName}.")
    //            .WithData(nameof(userName), userName)
    //            .WithErrorCode(InfrastructureErrorCode.UserLoginPasswordResetIsDisabled);

    //    if (!userLogins.Any(userLogin => !userLogin.User.IsDisabled))
    //        throw new InvalidOperationException($"Cannot reset password for disabled logins for user name:{userName}.")
    //            .WithData(nameof(userName), userName)
    //            .WithErrorCode(InfrastructureErrorCode.CannotResetPasswordForDisabledUser);

    //    if (userLogins.Select(userLogin => userLogin.UserId).Distinct().Count() > 1)
    //        throw new IdentityException($"User:{userName} has an invalid idenetity state.")
    //            .WithData(nameof(userName), userName)
    //            .WithErrorCode(InfrastructureErrorCode.InvalidIdentityState);

    //    IdentityUserLogin targetUserLogin = userLogins.First(userLogin => !userLogin.User.IsDisabled);

    //    // Some users due to legacy data might have more thatn one login.
    //    // However, since a request for password change has been made, other logins
    //    // are assumed obsolete and therefore deleted. Leave only a single login.
    //    _db.IdentityUserLogins.RemoveRange(userLogins.Where(userLogin => userLogin != targetUserLogin));

    //    string secret = MustResetPassword(targetUserLogin, true);

    //    _ = await _db.SaveChangesAsync(cancellationToken);

    //    Dictionary<string, string> templates = await _db.TextTemplates
    //        .Where(textTemplate => textTemplate.Code == TextTemplateCode.PasswordResetEmailBody
    //            || textTemplate.Code == TextTemplateCode.PasswordResetEmailSubject
    //            || textTemplate.Code == TextTemplateCode.EmailFooter)
    //        .ToDictionaryAsync(
    //            keySelector: textTemplate => textTemplate.Code,
    //            elementSelector: textTemplate => textTemplate.ContentLocalizationSubject.GetValue(Locale.LV),
    //            cancellationToken: cancellationToken);

    //    string subj = templates[TextTemplateCode.PasswordResetEmailSubject];

    //    if (string.IsNullOrEmpty(subj))
    //        throw new TemplateEmptyException(TextTemplateCode.PasswordResetEmailSubject);

    //    string body = templates[TextTemplateCode.PasswordResetEmailBody];

    //    if (string.IsNullOrEmpty(body))
    //        throw new TemplateEmptyException(TextTemplateCode.PasswordResetEmailBody);

    //    string footer = templates[TextTemplateCode.PasswordResetEmailSubject];

    //    body = body.Replace("{{url}}", _identityPasswordRecoverUrlProvider.Get(secret)) + footer;

    //    await _emailService.SendAsync(message: _emailService.CreateMessage(targetUserLogin.User.PersonTechnical.Person.Email, subj, body), cancellationToken: cancellationToken);
    //}

    ///// <inheritdoc/>
    //public async Task RemoveRefreshTokenAsync(string token, CancellationToken cancellationToken = default)
    //{
    //    IdentityRefreshToken item = await _db.IdentityRefreshTokens.Where(t => t.Value == token)
    //        .FirstOrDefaultAsync(cancellationToken);

    //    if (item == null)
    //        return;

    //    _ = _db.IdentityRefreshTokens.Remove(item);

    //    _ = await _db.SaveChangesAsync(cancellationToken);
    //}

    ///// <inheritdoc/>
    ///// <exception cref="EntityNotFoundException"></exception>
    ///// <exception cref="NotSupportedException"></exception>
    //public async Task<Guid> ResetPasswordAsync(Guid id, string password, CancellationToken cancellationToken = default)
    //{
    //    IdentityUserLogin login = await _db.IdentityUserLogins
    //        .FindAsync([id], cancellationToken);

    //    if (login == null)
    //        throw new EntityNotFoundException();

    //    PreventNonFormsPassword(login);
    //    PreventAdminUserUpdates(login);

    //    return !login.MustResetPassword
    //        ? throw new InvalidOperationException($"Password reset is not allowed for login:{id}.")
    //            .WithData("IdentityUserLoginId", id)
    //            .WithErrorCode(InfrastructureErrorCode.PasswordResetNotAllowed)
    //        : await SetPassword(login, password);
    //}

    ///// <inheritdoc/>
    ///// <exception cref="EntityNotFoundException"></exception>
    ///// <exception cref="NotSupportedException"></exception>
    //public async Task<Guid> ResetPasswordAsync(string secret, string password, CancellationToken cancellationToken = default)
    //{
    //    if (string.IsNullOrEmpty(secret))
    //        throw new ArgumentNullException(nameof(secret));

    //    IdentityUserLogin login = await _db.IdentityUserLogins.Where(t => t.PasswordResetKey == secret)
    //        .FirstOrDefaultAsync(cancellationToken);

    //    if (login == null)
    //        throw new EntityNotFoundException();

    //    PreventNonFormsPassword(login);
    //    PreventAdminUserUpdates(login);

    //    return !login.MustResetPassword
    //        ? throw new ValidationException("user.passwordResetDisabled")
    //        : await SetPassword(login, password);
    //}

    ///// <inheritdoc/>
    ///// <exception cref="EntityNotFoundException"></exception>
    //public async Task UpdateAsync(Guid userId, UserUpdateCommand command, CancellationToken cancellationToken = default)
    //{
    //    User user = await _db.Users.Where(t => t.Id == userId)
    //        .FirstOrDefaultAsync(cancellationToken);

    //    if (user == null)
    //        throw new EntityNotFoundException();

    //    if ((user.PersonTechnicalId != command.PersonTechnicalId || user.Role == command.Role)
    //        && await ExistsPersonAndRoleCombinationAsync(command.PersonTechnicalId, command.Role, cancellationToken))
    //        throw new InvalidOperationException($"User with person id:{command.PersonTechnicalId}, role:{command.Role} already exists.")
    //            .WithErrorCode(InfrastructureErrorCode.CannotHaveDuplicatesByPersonAndRole);

    //    user.IsDisabled = command.IsDisabled;
    //    user.Role = command.Role;

    //    user.SetPersonTechnicalId(command.PersonTechnicalId);

    //    _ = await _db.SaveChangesAsync(cancellationToken);
    //}

    ///// <inheritdoc/>
    //public async Task<VerifyPasswordResult> VerifyPasswordAsync(string username, string password, CancellationToken cancellationToken = default)
    //{
    //    IdentityUserLogin[] users = await _db.IdentityUserLogins.Where(t => t.UserName == username)
    //        .ToArrayAsync();

    //    return users.Length == 0
    //        ? VerifyPasswordResult.Fail()
    //        : await VerifyPasswordAsync(users, password);
    //}

    //private string MustResetPassword(IdentityUserLogin userLogin, bool force = false)
    //{
    //    PreventNonFormsPassword(userLogin);
    //    PreventAdminUserUpdates(userLogin);

    //    string secret = Guid.NewGuid().ToString("N");

    //    if (force)
    //        userLogin.PasswordHash = null;

    //    userLogin.PasswordResetKey = secret;
    //    userLogin.MustResetPassword = true;

    //    return secret;
    //}

    //private void PreventAdminUserUpdates(IdentityUserLogin user)
    //{
    //    if (user.UserName == UserName.Admin)
    //        throw new NotSupportedException();
    //}

    //private void PreventNonFormsPassword(IdentityUserLogin user)
    //{
    //    if (user.AuthType != UserAuthType.Forms)
    //        throw new NotSupportedException();
    //}

    //private async Task<Guid> SetPassword(IdentityUserLogin user, string password)
    //{
    //    PreventNonFormsPassword(user);

    //    if (!_passwordValidator.Validate(password))
    //        throw new ValidationException()
    //            .WithErrorCode(InfrastructureErrorCode.PasswordRequirementsNotMet);

    //    var passwordHasher = new PasswordHasher<IdentityUserLogin>();
    //    var hashedPassword = passwordHasher.HashPassword(user, password);

    //    user.PasswordResetKey = null;
    //    user.PasswordHash = hashedPassword;
    //    user.MustResetPassword = false;

    //    _ = await _db.SaveChangesAsync();

    //    return user.Id;
    //}

    //private async ValueTask<VerifyPasswordResult> VerifyPasswordAsync(IdentityUserLogin[] users, string password)
    //{
    //    if (string.IsNullOrEmpty(password))
    //        return VerifyPasswordResult.Fail();

    //    IPasswordHasher<IdentityUserLogin>[] hashers = [new PasswordHasher<IdentityUserLogin>(), new LegacyPasswordHasher<IdentityUserLogin>()];

    //    foreach (IdentityUserLogin user in users)
    //    {
    //        try
    //        {
    //            PreventNonFormsPassword(user);
    //        }
    //        catch (NotSupportedException)
    //        {
    //            continue;
    //        }

    //        foreach (IPasswordHasher<IdentityUserLogin> hasher in hashers)
    //        {
    //            try
    //            {
    //                PasswordVerificationResult passwordCheck = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

    //                if (passwordCheck == PasswordVerificationResult.Success)
    //                {
    //                    // TODO: Enable password validation after legacy application support ends.
    //                    // Work Item: #18949
    //                    //if (user.UserName != UserName.Admin && !_passwordValidator.Validate(password))
    //                    //    _ = await MustResetPasswordAsync(false, user);

    //                    _ = await _db.SaveChangesAsync();

    //                    return VerifyPasswordResult.Succeed(user.Id);
    //                }
    //                else if (passwordCheck == PasswordVerificationResult.SuccessRehashNeeded)
    //                {
    //                    if (user.UserName != UserName.Admin)
    //                        _ = MustResetPassword(user, false);

    //                    _ = await _db.SaveChangesAsync();

    //                    return VerifyPasswordResult.Succeed(user.Id);
    //                }
    //            }
    //            catch (Exception) { }
    //        }
    //    }

    //    return VerifyPasswordResult.Fail();
    //}

    ///// <summary>
    ///// Check if identity user login exists.
    ///// </summary>
    ///// <param name="userName">User name to check.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>True - if exists; False - of does not exist.</returns>
    //private Task<bool> ExistsAsync(string userName, CancellationToken cancellationToken)
    //    => _db.IdentityUserLogins.AnyAsync(identityUserLogin => identityUserLogin.UserName.ToLower() == userName.ToLower(), cancellationToken);

    ///// <summary>
    ///// Check if user exists.
    ///// </summary>
    ///// <param name="userName">User name to check.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>True - if exists; False - of does not exist.</returns>
    //private Task<bool> ExistsPersonAndRoleCombinationAsync(Guid personTechnicalId, UserRole role, CancellationToken cancellationToken)
    //    => _db.IdentityUserLogins.AnyAsync(
    //            identityUserLogin => identityUserLogin.User.Role == role
    //            && identityUserLogin.User.PersonTechnicalId == personTechnicalId,
    //        cancellationToken);
}
