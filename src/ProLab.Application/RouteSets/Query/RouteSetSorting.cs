using ProLab.Application.Common.Query;
using ProLab.Domain.Routes;
using System.Linq.Expressions;

namespace ProLab.Application.RouteSets.Query;

public class RouteSetSorting : SortingParameters<RouteSet>
{
    protected override Dictionary<string, Expression<Func<RouteSet, object>>[]> SortingOptions { get; } = new(StringComparer.OrdinalIgnoreCase)
    {
        ["created"] =
        [
            routeSet => routeSet.Created
        ],

        ["id"] =
        [
            routeSet => routeSet.Id
        ],
    };
}
