namespace Models.Filters;

public class Filter
{
    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string SortBy { get; set; } = "Code";

    public bool SortDesc { get; set; } = false;
}