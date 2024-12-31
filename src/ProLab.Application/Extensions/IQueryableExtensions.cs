using ProLab.Application.Common.Query;
using System.Linq.Expressions;

namespace ProLab.Application.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, PagingParameters? parameters)
    {
        if (parameters == null)
            return query;

        return query
            .Skip((parameters.CurrentPage - 1) * parameters.PageSize)
            .Take(parameters.PageSize);
    }

    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, SortingParameters<T>? parameters)
        where T : class
    {
        if (parameters == null)
            return query;

        Expression<Func<T, object>>[]? expressions = parameters.GetSorting();

        if (expressions == null || expressions.Length == 0)
            return query;

        for (int ix = 0; ix < expressions.Length; ix++)
            _ = query.ApplyOrder(expressions[ix], parameters.IsDescending);

        return query;
    }

    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, FilterParameters<T>? parameters)
        where T : class
    {
        if (parameters == null)
            return query;

        List<Expression<Func<T, bool>>> filters = parameters.GetFilters();

        foreach (Expression<Func<T, bool>> currentFilter in filters)
            query = query.Where(currentFilter);

        return query;
    }

    public static IOrderedQueryable<T> ApplyOrder<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> keySelector, bool isDescending)
    {
        if (source is IOrderedQueryable<T> orderedQuery)
        {
            return isDescending
                ? orderedQuery.ThenByDescending(keySelector)
                : orderedQuery.ThenBy(keySelector);
        }

        return isDescending
            ? source.OrderByDescending(keySelector)
            : source.OrderBy(keySelector);
    }
}
