namespace Houlight.Application.Common.Models;

public class PaginationFilter
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;
    private int _pageNumber = 1;
    private string _orderBy = "CreatedDate";
    private bool _orderByDescending = true;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value < 1 ? 1 : value;
    }

    public string OrderBy
    {
        get => _orderBy;
        set => _orderBy = string.IsNullOrWhiteSpace(value) ? "CreatedDate" : value;
    }

    public bool OrderByDescending
    {
        get => _orderByDescending;
        set => _orderByDescending = value;
    }

    public string? SearchTerm { get; set; }
} 