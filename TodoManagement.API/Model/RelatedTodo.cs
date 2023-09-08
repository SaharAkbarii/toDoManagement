namespace TodoManagement.API.Model;

public class RelatedTodo : Entity
{
    protected RelatedTodo()
    {

    }
    public RelatedTodo(ToDo toDo, ToDo relatedToDo, RelationStatus relationStatus)
    {
        ToDo = toDo;
        RelatedToDo = relatedToDo;
        RelationStatus = relationStatus;
    }

    public ToDo ToDo {get; set;}
    public ToDo RelatedToDo {get; set;}
    public RelationStatus RelationStatus {get; set;}
    
}

public enum RelationStatus
{
    BlockedBy = 0,
    RelatedTo = 1,
    Blocks = 2,
}