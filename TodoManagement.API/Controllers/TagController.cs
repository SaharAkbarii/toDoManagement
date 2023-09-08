using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoManagement.API.AppService;
using TodoManagement.API.DTO;
using TodoManagement.API.Model;

namespace TodoManagement.API.Controllers;

[ApiController]
[Route("[controller]")]

public class TagController : ControllerBase
{
    private readonly TagAppService service;
    private readonly IMapper mapper;

    public TagController(TagAppService service, IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    [HttpPost]
    public TagDto Add([FromBody] CreateTagInput input)
    {
        var tag = service.GetOrCreate(input.Title);
        var dto = mapper.Map<TagDto>(tag);
        return dto;
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public void Remove(Guid id)
    {
        service.Remove(id);
    }
    [HttpGet]
    [Route("{id:guid}")]
    public TagDto Get(Guid id)
    {
        var tag = service.Get(id);
        var dto = mapper.Map<TagDto>(tag);
        return dto;
    }

    [HttpGet]
    public List<TagDto> GetAll()
    {
        var tags = service.GetAll();
        var dto = mapper.Map<List<TagDto>>(tags);
        return dto;
    }

}
