using TodoManagement.API.Model;

namespace TodoManagement.API.DTO;

public class TodoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ToDoStatusDto Status { get; set; }
    public Guid? AssigneeId { get; set; }
    public bool IsApproved { get; set; }
    public Guid? ApprovedById { get; set; }
    public DateTimeOffset? ApprovedDate { get; set; }
    public Guid Id {get; set;}
    public Guid? ProjectId {get; set;}
    public int StoryPoint{get; set;}
    public List<CheckListItemDto> CheckList {get; set;}
    public List<RelatedTodoDto> RelatedTodos {get; set;}
    public List<TagToDoDto> Tags {get; set;}
    public Guid? SprintId { get; set; }
}

public enum ToDoStatusDto
{
    Open = 0,
    InProgress = 1,
    Done = 2,
}
