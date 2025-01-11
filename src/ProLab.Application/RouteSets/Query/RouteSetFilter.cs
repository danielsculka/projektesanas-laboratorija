using ProLab.Application.Common.Query;
using ProLab.Domain.Routes;
using System.Linq.Expressions;

namespace ProLab.Application.RouteSets.Query;

public class RouteSetFilter : FilterParameters<RouteSet>
{
    public DateOnly? Date { get; set; }

    public override List<Expression<Func<RouteSet, bool>>> GetFilters()
    {
        var filters = new List<Expression<Func<RouteSet, bool>>>(1);

        if (Date != null)
            filters.Add(routeSet => routeSet.Date == Date);

        return filters;
    }
}
