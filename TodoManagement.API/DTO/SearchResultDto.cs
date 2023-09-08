namespace TodoManagement.API.DTO;

public class SearchResultDto<TResult>
{
    public List<TResult> Results {get; set;}
    public int TotalCount {get; set;}
}