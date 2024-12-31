using ProLab.Application.Common.Query;
using ProLab.Domain.Orders;
using System.Linq.Expressions;

namespace ProLab.Application.Orders.Query;

public class OrderSorting : SortingParameters<Order>
{
    protected override Dictionary<string, Expression<Func<Order, object>>[]> SortingOptions { get; } = new(StringComparer.OrdinalIgnoreCase)
    {
        ["name"] =
        [
            order => order.Number
        ],

        ["id"] =
        [
            order => order.Id
        ],
    };
}
