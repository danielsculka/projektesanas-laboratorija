using ProLab.Application.Common.Query;
using ProLab.Domain.Warehouses;
using System.Linq.Expressions;

namespace ProLab.Application.Warehouses.Query;

public class WarehouseSorting : SortingParameters<Warehouse>
{
    protected override Dictionary<string, Expression<Func<Warehouse, object>>[]> SortingOptions { get; } = new(StringComparer.OrdinalIgnoreCase)
    {
        ["name"] =
        [
            warehouse => warehouse.Name,
        ],

        ["id"] =
        [
            warehouse => warehouse.Id
        ],
    };
}
