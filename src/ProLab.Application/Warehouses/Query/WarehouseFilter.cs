using ProLab.Application.Common.Query;
using ProLab.Domain.Warehouses;
using System.Linq.Expressions;

namespace ProLab.Application.Warehouses.Query;

public class WarehouseFilter : FilterParameters<Warehouse>
{
    public string? Search { get; set; }

    public override List<Expression<Func<Warehouse, bool>>> GetFilters()
    {
        var filters = new List<Expression<Func<Warehouse, bool>>>(1);

        if (!string.IsNullOrEmpty(Search))
        {
            var search = Search.Trim().ToLower();

            filters.Add(warehouse => warehouse.Name.ToLower().Contains(search));
        }

        return filters;
    }
}
