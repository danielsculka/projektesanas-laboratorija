namespace ProLab.Application.Common.Query;

public class QueryParameters<T>
    where T : class
{
    public FilterParameters<T>? Filter { get; set; }
    public SortingParameters<T>? Sorting { get; set; }
    public PagingParameters? Paging { get; set; }
}
