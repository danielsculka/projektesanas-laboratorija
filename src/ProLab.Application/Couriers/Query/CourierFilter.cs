using ProLab.Application.Common.Query;
using ProLab.Domain.Couriers;
using System.Linq.Expressions;

namespace ProLab.Application.Couriers.Query;

public class CourierFilter : FilterParameters<Courier>
{
    public string? Search { get; set; }

    public override List<Expression<Func<Courier, bool>>> GetFilters()
    {
        var filters = new List<Expression<Func<Courier, bool>>>(1);

        if (!string.IsNullOrEmpty(Search))
        {
            var search = Search.Trim().ToLower();

            filters.Add(courier => (courier.FirstName + ' ' + courier.LastName).ToLower().Contains(search));
        }

        return filters;
    }
}
