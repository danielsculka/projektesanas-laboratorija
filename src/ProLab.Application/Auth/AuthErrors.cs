using ProLab.Application.Common.Errors;

namespace ProLab.Application.Orders;

public static class AuthErrors
{

    public static readonly Error NotFound = new("Users.NotFound", $"User not found.", ErrorType.NotFound);

    public static readonly Error AlreadyExists = new("Users.AlreadyExists", "User already exists.", ErrorType.Conflict);

    public static readonly Error ValidationException = new("Users.ValidationExcpetion", "Users password is not correct.", ErrorType.ValidationError);
}
