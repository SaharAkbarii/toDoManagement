using Microsoft.AspNetCore.Mvc;
using TodoManagement.API.DTO;
using TodoManagement.API.Model;
using TodoManagement.API.AppService;
using TodoManagement.API.Repository;
using AutoMapper;

namespace TodoManagement.API.Controllers;

[ApiController]
[Route("[controller]")]

public class ToDoController : ControllerBase
{
    private readonly ToDoAppService service;
    private readonly IMapper mapper;
    public ToDoController(ToDoAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }
    [HttpPost]
    public TodoDto Create([FromBody] CreateToDoInput input)
    {
        var toDo = service.Create(input.Title, input.Description, input.ProjectId, input.StoryPoint, input.SprintId);
        var dto = mapper.Map<TodoDto>(toDo);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}")]
    public TodoDto Update(Guid id, [FromBody] UpdateToDoInput input)
    {
        var toDo = service.Update(id, input.Title, input.Description, input.ProjectId, input.StoryPoint, input.SprintId);
        var dto = mapper.Map<TodoDto>(toDo);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}/status")]
    public TodoDto UpdateStatus(Guid id, [FromBody] UpdateToDoStatusInput input)
    {
        var toDo = service.UpdateStatus(id, input.Status);
        var dto = mapper.Map<TodoDto>(toDo);
        return dto;

    }

    [HttpPut]
    [Route("{id:guid}/assign/{personId:guid}")]
    public TodoDto Assign(Guid id, Guid personId)
    {
        var toDo = service.Assign(id, personId);
        var dto = mapper.Map<TodoDto>(toDo);
        return dto;
    }

    [HttpGet]
    public List<TodoDto> GetAll()
    {
        try 
        {
        var toDos = service.GetAll();
        var dto = mapper.Map<List<TodoDto>?>(toDos);

        return dto;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    [HttpGet]
    [Route("{id:guid}")]
    public TodoDto Get(Guid id)
    {
        var toDo = service.Get(id);
        var dto = mapper.Map<TodoDto>(toDo);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}/approve/{personId:guid}")]
    public TodoDto Approve(Guid id, Guid personId)
    {
        var toDo = service.Approved(id, personId);
        var dto = mapper.Map<TodoDto>(toDo);
        return dto;
    }

    [HttpPost]
    [Route("{id:guid}/checklist/add")]
    public CheckListItemDto AddCheckListItem(Guid id, [FromBody] AddCheckListItemInput input)
    {
        var checkListItem = service.AddCheckListItem(id, input.Title, input.IsChecked);
        var dto = mapper.Map<CheckListItemDto>(checkListItem);
        return dto;
    }

    [HttpPut]
    [Route("{toDoId:guid}/checklist/update/{checkListId:guid}")]
    public CheckListItemDto UpdateCheckListItem(Guid toDoId, Guid checkListId, [FromBody] UpdateCheckListItemInput input)
    {
        var checkListItem = service.UpdateCheckListItem(toDoId, checkListId, input.Title, input.IsChecked);
        var dto = mapper.Map<CheckListItemDto>(checkListItem);
        return dto;
    }

    [HttpDelete]
    [Route("{toDoId:guid}/checklist/{checkListId:guid}")]

    public void RemoveCheckListItem(Guid checkListId)
    {
        service.RemoveCheckListItem(checkListId);
    }

    [HttpPut]
    [Route("{toDoId:guid}/related/add")]

    public TodoDto AddRelatedTodo(Guid toDoId, [FromBody] AddRelatedTodoInput input)
    {
        var relation = service.AddRelatedTodo(toDoId, input.RelatedToDoId, input.RelationStatus);
        var dto = mapper.Map<TodoDto>(relation);
        return dto;
    }

    [HttpDelete]
    [Route("{mainTodoId:guid}/relation/{relationId:guid}")]
    public void RemoveRelatedTodo(Guid mainTodoId, Guid relationId)
    {

        service.RemoveRelatedTodo(mainTodoId, relationId);
    }

    [HttpGet]
    [Route("search/{keyword}/{offset:int}/{count:int}")]
    public SearchResultDto<TodoDto> SearchTodo(string keyword, int offset, int count)
    {
        var toDos = service.Search(keyword, count, offset);
        var dto= mapper.Map<SearchResultDto<TodoDto>>(toDos);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}/add/tag")]
    public TodoDto AddTag(Guid id, [FromBody] CreateTagInput input)
    {
        var toDo = service.AddTag(id, input.Title);
        var dto = mapper.Map<TodoDto>(toDo);
        return dto;

    }

    [HttpPost]
    [Route("search/bytags")]
    public List<TodoDto> SearchByTags([FromBody] SearchByTagsInput input)
    {
        var toDos = service.SearchByTags(input.TagsId);
        var dto = mapper.Map<List<TodoDto>>(toDos);
        return dto;
    }

}


