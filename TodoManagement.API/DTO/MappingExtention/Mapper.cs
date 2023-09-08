using TodoManagement.API.Model;

namespace TodoManagement.API.DTO;

[Obsolete("instead of this class use auto mapper.")]
public static class Mapper
{
    [Obsolete("instead of this class use auto mapper.")]
    public static TodoDto ToDto(this ToDo toDo)
    {
        var dto = new TodoDto()
        {
            Title = toDo.Title,
            Description = toDo.Description,
            Status = Enum.Parse<ToDoStatusDto>(toDo.Status.ToString()),
            AssigneeId = toDo.Assignee?.Id,
            IsApproved = toDo.IsApproved,
            ApprovedById = toDo.ApprovedBy?.Id,
            ApprovedDate = toDo.ApprovedDate,
            ProjectId = toDo.Project?.Id,
            StoryPoint = toDo.StoryPoint,
            CheckList = toDo.CheckList.ToDto(),
            Id = toDo.Id,
            RelatedTodos = toDo.RelatedTodos.ToDto(),
            Tags = toDo.Tags.ToDto(),
            SprintId = toDo.Sprint?.Id
        };
        return dto;
    }

    public static List<TodoDto> ToDto(this List<ToDo> toDos)
    {
        return toDos?.Select(x => x.ToDto()).ToList();
    }
    public static PersonDto ToDto(this Person person)
    {
        var dto = new PersonDto()
        {
            Name = person.Name,
            Id = person.Id,
            Todos = person.ToDos.ToDto(),
        };
        return dto;
    }
    public static List<PersonDto> ToDto(this List<Person> people)
    {
        return people.Select(x => x.ToDto()).ToList();
    }

    public static ProjectDto ToDto(this Project project)
    {
        var dto = new ProjectDto()
        {
            Name = project.Name,
            Description = project.Description,
            Id = project.Id,
            DeadLine = project.DeadLine,
            ToDos = project.ToDos.ToDto(),
            ProgressPercent = project.ProgressPercent,
            DeadLineState = project.DeadLineState
        };
        return dto;
    }

    public static List<ProjectDto> ToDto(this List<Project> projects)
    {
        return projects.Select(x => x.ToDto()).ToList();
    }
    public static CheckListItemDto ToDto(this CheckListItem checkListItem)
    {
        var dto = new CheckListItemDto()
        {
            Title = checkListItem.Title,
            IsChecked = checkListItem.IsChecked,
            Id = checkListItem.Id
        };
        return dto;
    }
    public static List<CheckListItemDto> ToDto(this List<CheckListItem> checkListItem)
    {
        return checkListItem?.Select(x => x.ToDto()).ToList();
    }

    public static RelatedTodoDto ToDto(this RelatedTodo relatedTodo)
    {
        var dto = new RelatedTodoDto()
        {
            MainToDoId = relatedTodo.ToDo.Id,
            RelatedToDoId = relatedTodo.RelatedToDo.Id,
            RelationStatus = Enum.Parse<RelationStatusDto>(relatedTodo.RelationStatus.ToString()),
        };
        return dto;
    }

    public static List<RelatedTodoDto> ToDto(this List<RelatedTodo> relatedTodo)
    {
        return relatedTodo?.Select(x => x.ToDto()).ToList();
    }

    public static SearchResultDto<TodoDto> ToDto(this SearchResult<ToDo> searchResult)
    {
        var dto = new SearchResultDto<TodoDto>()
        {
            Results = searchResult.Results.ToDto(),
            TotalCount = searchResult.TotalCount
        };
        return dto;
    }

    public static SearchResultDto<ProjectDto> ToDto(this SearchResult<Project> searchResult)
    {
        var dto = new SearchResultDto<ProjectDto>()
        {
            Results = searchResult.Results.ToDto(),
            TotalCount = searchResult.TotalCount
        };
        return dto;
    }

    public static SearchResultDto<PersonDto> ToDto(this SearchResult<Person> searchResult)
    {
        var dto = new SearchResultDto<PersonDto>()
        {
            Results = searchResult.Results.ToDto(),
            TotalCount = searchResult.TotalCount
        };
        return dto;
    }

    public static TagDto ToDto(this Tag tag)
    {
        var dto = new TagDto
        {
            Title = tag.Title,
            Id = tag.Id
        };
        return dto;
    }

    public static List<TagDto> ToDto(this List<Tag> tags)
    {
        return tags.Select(x => x.ToDto()).ToList();
    }

    public static TagToDoDto ToDto(this TagToDo tagToDo)
    {
        var dto = new TagToDoDto
        {
            Id = tagToDo.Id,
            Tag = tagToDo.Tag.ToDto()
        };
        return dto;
    }
    public static List<TagToDoDto> ToDto(this List<TagToDo> tagtodos)
    {
        return tagtodos?.Select(x => x.ToDto()).ToList();
    }

    public static WorkspaceSettingDto ToDto(this WorkspaceSetting workspaceSetting)
    {
        var dto = new WorkspaceSettingDto
        {
            Id = workspaceSetting.Id,
            TargetNotificationAddress = workspaceSetting.TargetNotificationAddress,
            Channel = Enum.Parse<NotificationChannelDto>(workspaceSetting.Channel.ToString())
        };
        return dto;
    }
    public static SprintDto ToDto(this Sprint sprint)
    {
        var dto = new SprintDto
        {
            Name = sprint.Name,
            StartDate = sprint.StartDate,
            EndDate = sprint.EndDate,
            ToDos = sprint.ToDos.ToDto(),
            Id = sprint.Id
        };
        return dto;
    }
    public static List<SprintDto> ToDto(this List<Sprint> sprints)
    {
        return sprints?.Select(x => x.ToDto()).ToList();
    }
}
