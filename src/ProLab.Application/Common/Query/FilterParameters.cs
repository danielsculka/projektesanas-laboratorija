using System.Linq.Expressions;

namespace ProLab.Application.Common.Query;

public abstract class FilterParameters<T>
    where T : class
{
    public abstract List<Expression<Func<T, bool>>> GetFilters();
}
