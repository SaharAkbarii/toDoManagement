using AutoMapper;
using TodoManagement.API.DTO;
using TodoManagement.API.Model;

namespace TodoManagement.API;
public class TodoManagementMappingProfile : Profile
{
    public TodoManagementMappingProfile()
    {
        CreateMap<ToDo, TodoDto>();
            // .ForMember(dest => dest.AssigneeId, 
                // x=> x.MapFrom((src, dest, destMember, context)=> src.Assignee?.Id));

        
        CreateMap<ToDoStatus, ToDoStatusDto>();
        CreateMap<CheckListItem, CheckListItemDto>();
        CreateMap<Person, PersonDto>();
        CreateMap<SearchResult<Person>, SearchResultDto<PersonDto>>();
        CreateMap<CheckListItem, CheckListItemDto>();
        CreateMap<SearchResult<ToDo>, SearchResultDto<TodoDto>>();
        CreateMap<Project, ProjectDto>();
        CreateMap<SearchResult<Project>, SearchResultDto<ProjectDto>>();
        CreateMap<Tag, TagDto>();
        CreateMap<Sprint, SprintDto>();
        CreateMap<RelatedTodo, RelatedTodoDto>()
            .ForMember(dest => dest.MainToDoId, 
                x=> x.MapFrom((src, dest, destMember, context)=> src.ToDo.Id));
        CreateMap<RelationStatus, RelationStatusDto>();
        CreateMap<TagToDo, TagToDoDto>();

    }
}

            // AssigneeId = toDo.Assignee?.Id, 
            // ApprovedById = toDo.ApprovedBy?.Id,
            // ProjectId = toDo.Project?.Id,