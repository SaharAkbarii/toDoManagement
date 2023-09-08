namespace TodoManagement.API.Model;

public class SearchResult<TResult>
{
    public SearchResult(List<TResult> results, int totalCount)
    {
        Results = results;
        TotalCount = totalCount;
    }

    public List<TResult> Results { get; set; }
    public int TotalCount { get; set; }
}
