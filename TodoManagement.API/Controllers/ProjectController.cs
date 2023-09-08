using Microsoft.AspNetCore.Mvc;
using TodoManagement.API.DTO;
using TodoManagement.API.Model;
using TodoManagement.API.AppService;
using AutoMapper;

namespace TodoManagement.API.Controllers;

[ApiController]
[Route("[controller]")]

public class ProjectController : ControllerBase
{
    private readonly ProjectAppService service;
    private readonly IMapper mapper;

    public ProjectController(ProjectAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public ProjectDto Add([FromBody] CreateProjectInput input)
    {
        var project = service.Create(input.Name, input.Description, input.DeadLine);
        var dto = mapper.Map<ProjectDto>(project);
        return dto;
    }

    [HttpPut]
    [Route("{id:guid}")]
    public ProjectDto Update(Guid id, [FromBody] UpdateProjectInput input)
    {
        var project = service.Update(id, input.Name, input.Description, input.DeadLine);
        var dto = mapper.Map<ProjectDto>(project);
        return dto;
    }

    [HttpGet]
    public List<ProjectDto> GetAll()
    {
        var projects = service.GetAll();
        var dto = mapper.Map<List<ProjectDto>>(projects);
        return dto;
    }

    [HttpGet]
    [Route("search/{keyword}/{offset:int}/{count:int}")]
    public SearchResultDto<ProjectDto> SearchProject(string keyword, int offset, int count)
    {
        var projects = service.Search(keyword, count, offset);
        var dto = mapper.Map<SearchResultDto<ProjectDto>>(projects);
        return dto;
       
    }


    [HttpGet]
    [Route("{id:guid}")]
    public ProjectDto Get(Guid id)
    {

        var project = service.Get(id);
        var dto = mapper.Map<ProjectDto>(project);
        return dto;
    }
}
