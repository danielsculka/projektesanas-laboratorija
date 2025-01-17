﻿namespace ProLab.Application.Common.Results;

public class PagedListResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }

    public PagedListResult(T[] items, int totalCount, int? pageSize, int? currentPage)
    {
        Items = items;
        TotalCount = totalCount;
        PageSize = pageSize ?? totalCount;
        CurrentPage = currentPage ?? 1;
    }
}
