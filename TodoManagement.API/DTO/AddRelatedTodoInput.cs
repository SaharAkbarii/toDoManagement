using TodoManagement.API.Model;


namespace TodoManagement.API.DTO;

public class AddRelatedTodoInput
{
    public Guid RelatedToDoId { get; set; }
    public RelationStatus RelationStatus { get; set; }
}
