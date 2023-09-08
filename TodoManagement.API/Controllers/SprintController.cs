using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoManagement.API.AppService;
using TodoManagement.API.DTO;

namespace TodoManagement.API.Controllers;

[ApiController]
[Route("[controller]")]

public class SprintController : ControllerBase
{
    private readonly SprintAppService service;
    private readonly IMapper mapper;
    public SprintController(SprintAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public SprintDto Create([FromBody] CreateSprintInput input)
    {
        var sprint = service.Create(input.Name, input.StartDate, input.EndDate);
        var dto = mapper.Map<SprintDto>(sprint);
        return dto;
    }
    [HttpPut]
    [Route("{id:guid}")]
    public SprintDto Update(Guid id, [FromBody] UpdateSprintInput input)
    {
        var sprint = service.Update(id, input.Name, input.StartDate, input.EndDate);
        var dto = mapper.Map<SprintDto>(sprint);
        return dto;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public SprintDto Get(Guid id)
    {
        var sprint = service.Get(id);
        var dto = mapper.Map<SprintDto>(sprint);
        return dto;
    }

    [HttpGet]
    public List<SprintDto> GetAll()
    {
        var sprints = service.GetAll();
        var dto = mapper.Map<List<SprintDto>>(sprints);
        return dto;
    }
}
