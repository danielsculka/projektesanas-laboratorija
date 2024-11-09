namespace ProLab.Application.Orders;

public class OrderService
{
    private readonly IAppDbContext _db;
    private readonly IOrderService _orderService;

    public OrderService(IAppDbContext db, IOrderService orderService)
    {
        _db = db;
        _orderService = orderService;
    }
}
