namespace TodoManagement.API.Model;

public class ChangeTodoStatusHistory: Entity
{
    protected ChangeTodoStatusHistory()
    {
    }

    public ChangeTodoStatusHistory(ToDoStatus currentStatus, ToDo toDo)
    {
        CurrentStatus = currentStatus;
        ToDo = toDo;
        ChangedAt= DateTimeOffset.UtcNow;
    }

    public DateTimeOffset ChangedAt {get; set;}
    public ToDoStatus CurrentStatus {get; set;}
    public virtual ToDo ToDo {get; set;}
    public Guid ToDoId {get; set;}

}
