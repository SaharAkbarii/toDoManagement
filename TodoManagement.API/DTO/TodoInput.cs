using TodoManagement.API.Model;

namespace TodoManagement.API.DTO;

public class UpdateToDoInputBase
{
    public string Title{get; set;}
    public string Description{get; set;}
    public Guid? ProjectId {get; set;}
    public int StoryPoint{get; set;}
    public Guid? SprintId{get; set;}
    
}
public class CreateToDoInput : UpdateToDoInputBase
{
}

public class UpdateToDoInput : UpdateToDoInputBase
{
}

public class UpdateToDoStatusInput
{
    public ToDoStatus Status {get; set;}
}
