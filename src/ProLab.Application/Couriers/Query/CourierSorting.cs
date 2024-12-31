using ProLab.Application.Common.Query;
using ProLab.Domain.Couriers;
using System.Linq.Expressions;

namespace ProLab.Application.Couriers.Query;

public class CourierSorting : SortingParameters<Courier>
{
    protected override Dictionary<string, Expression<Func<Courier, object>>[]> SortingOptions { get; } = new(StringComparer.OrdinalIgnoreCase)
    {
        ["name"] =
        [
            courier => courier.FirstName,
            courier => courier.LastName
        ],

        ["id"] =
        [
            courier => courier.Id
        ],
    };
}
