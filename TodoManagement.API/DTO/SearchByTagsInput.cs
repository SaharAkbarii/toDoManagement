using TodoManagement.API.Model;

namespace TodoManagement.API.DTO;

public class SearchByTagsInput
{
    public List<Guid> TagsId { get; set; }
}