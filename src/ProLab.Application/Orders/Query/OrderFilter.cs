using ProLab.Application.Common.Query;
using ProLab.Domain.Orders;
using System.Linq.Expressions;

namespace ProLab.Application.Orders.Query;

public class OrderFilter : FilterParameters<Order>
{
    public string? Search { get; set; }

    public override List<Expression<Func<Order, bool>>> GetFilters()
    {
        var filters = new List<Expression<Func<Order, bool>>>(1);

        if (!string.IsNullOrEmpty(Search))
        {
            var search = Search.Trim().ToLower();

            filters.Add(order => order.Number.ToLower().Contains(search));
        }

        return filters;
    }
}
