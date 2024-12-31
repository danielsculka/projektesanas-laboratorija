using ProLab.Application.Common.Errors;

namespace ProLab.Application.Couriers;

public static class CourierErrors
{
    public static readonly Error CommandShouldNotBeNull = new("Couriers.CommandShouldNotBeNull", $"Command should not be Null.", ErrorType.BadRequest);

    public static readonly Error NotFound = new("Couriers.NotFound", $"Courier not found.", ErrorType.NotFound);

    public static readonly Error AlreadyExists = new("Couriers.AlreadyExists", "Courier already exists.", ErrorType.Conflict);
}
