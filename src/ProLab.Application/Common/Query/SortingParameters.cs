using System.Linq.Expressions;

namespace ProLab.Application.Common.Query;

public abstract class SortingParameters<T>
    where T : class
{
    public string Sort { get; set; }
    public bool IsDescending { get; set; }

    protected abstract Dictionary<string, Expression<Func<T, object>>[]> SortingOptions { get; }

    public Expression<Func<T, object>>[]? GetSorting()
    {
        if (string.IsNullOrEmpty(Sort) || !SortingOptions.ContainsKey(Sort.ToLower()))
            return null;

        return SortingOptions[Sort.ToLower()];
    }
}
