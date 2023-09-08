using TodoManagement.API.Model;

namespace TodoManagement.API.DTO;


public class RelatedTodoDto
{
    public Guid MainToDoId { get; set; }
    public Guid RelatedToDoId { get; set; }
    public RelationStatusDto RelationStatus { get; set; }
}

public enum RelationStatusDto
{
    BlockedBy = 0,
    RelatedTo = 1,
    Blocks = 2,
}