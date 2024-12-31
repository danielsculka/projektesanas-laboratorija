using ProLab.Application.Common.Errors;

namespace ProLab.Application.Orders;

public static class OrderErrors
{

    public static readonly Error NotFound = new("Orders.NotFound", $"Order not found.", ErrorType.NotFound);

    public static readonly Error AlreadyExists = new("Orders.AlreadyExists", "Order already exists.", ErrorType.Conflict);
}
