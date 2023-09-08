using System;
using System.Text.Json.Serialization;
using TodoManagement.API.Exceptions;

namespace TodoManagement.API.Model;

public class ToDo : Entity
{
    private string title;

    public ToDo(string title, string description)
    {
        Title = title;
        Description = description;
        Status = ToDoStatus.Open;
        ChangeTodoStatusHistories = new List<ChangeTodoStatusHistory>();
        CheckList = new List<CheckListItem>();
        RelatedTodos = new List<RelatedTodo>();
        Tags = new List<TagToDo>();
    }

    public string Title
    {
        get => title; set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ValidationException("Title has to contain a value!");
            title = value;
        }
    }
    public string Description { get; set; }
    public ToDoStatus Status { get; set; }
    [JsonIgnore]
    public Person? Assignee { get; set; }
    public bool IsApproved { get; set; }
    [JsonIgnore]
    public Person? ApprovedBy { get; set; }
    public DateTimeOffset? ApprovedDate { get; set; }
    public Project? Project { get; set; }
    public List<ChangeTodoStatusHistory> ChangeTodoStatusHistories { get; set; }
    public int StoryPoint { get; set; }
    public List<CheckListItem> CheckList { get; set; }
    public List<RelatedTodo> RelatedTodos { get; set; }
    public List<TagToDo> Tags { get; set; }
    public Sprint? Sprint { get; set; }

    public void Assign(Person person)
    {
        Assignee = person;
    }
    public void Approve(Person person)
    {
        if (Status != ToDoStatus.Done)
            throw new ValidationException("Only done task can be approved.");

        if (IsApproved)
            throw new ValidationException("this task has already been approved.");

        ApprovedBy = person;
        ApprovedDate = DateTimeOffset.UtcNow;
        IsApproved = true;
    }

    public void ChangeStatus(ToDoStatus status)
    {
        Status = status;
    }

    public void AddCheckListItem(CheckListItem item)
    {
        CheckList.Add(item);
    }

    public void AddRelatedTodos(RelatedTodo relatedTodo)
    {
        RelatedTodos.Add(relatedTodo);
    }

    public void RemoveRelatedTodo(Guid relationId)
    {
        var relation = RelatedTodos.FirstOrDefault(x => x.Id == relationId);
        RelatedTodos.Remove(relation);
    }

    public void AddTags(TagToDo tagToDo)
    {
        Tags.Add(tagToDo);
    }

    public void RemoveTag(Guid tagToDoId)
    {
        var tag = Tags.FirstOrDefault(x => x.Id == tagToDoId);
        Tags.Remove(tag);
    }
}

public enum ToDoStatus
{
    Open = 0,
    InProgress = 1,
    Done = 2,
}
