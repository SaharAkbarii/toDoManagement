using Microsoft.AspNetCore.Mvc;
using TodoManagement.API.DTO;
using TodoManagement.API.AppService;
using AutoMapper;

namespace TodoManagement.API.Controllers;

[ApiController]
[Route("[controller]")]

public class PersonController : ControllerBase
{
    private readonly PersonAppService service;
    private readonly IMapper mapper;
    public PersonController(PersonAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public PersonDto Add([FromBody] CreatePersonInput input)
    {
        var person = service.Create(input.Name);
        var dto = mapper.Map<PersonDto>(person);
        return dto;
    }

    [HttpGet]
    public List<PersonDto> GetAll()
    {
        var people = service.GetAll();
        var dto = mapper.Map<List<PersonDto>>(people);
        return dto;
    }

    [HttpGet]
    [Route("{id:guid}/todos")]
    public List<TodoDto> GetAllToDosByPerson(Guid id)
    {
        var toDos = service.GetAllToDosByPerson(id);
        var dto = mapper.Map<List<TodoDto>>(toDos);
        return dto;
    }

    [HttpGet]
    [Route("search/{keyword}/{offset:int}/{count:int}")]
    public SearchResultDto<PersonDto> SearchProject(string keyword, int offset, int count)
    {
        var people = service.Search(keyword, count, offset);
        var dto = mapper.Map<SearchResultDto<PersonDto>>(people);
        return dto;
    }


    [HttpGet]
    [Route("{id:guid}")]
    public PersonDto Get(Guid id)
    {
        var person = service.Get(id);
        var dto = mapper.Map<PersonDto>(person);
        return dto;
    }
}
