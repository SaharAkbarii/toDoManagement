using Microsoft.AspNetCore.Mvc;
using TodoManagement.API.AppService;
using TodoManagement.API.DTO;
using TodoManagement.API.Model;

namespace TodoManagement.API.Controllers;
[ApiController]
[Route("[controller]")]

public class WorkspaceSettingController : ControllerBase
{
    private WorkspaceSettingAppService service;
    public WorkspaceSettingController(WorkspaceSettingAppService service)
    {
        this.service = service;
    }
    [HttpPut]
    public WorkspaceSettingDto Update([FromBody] UpdateWorkspaceSettingInput input)
    {
        var WorkspaceSetting = service.Update(input.TargetNotificationAddress, Enum.Parse<NotificationChannel>(input.Channel.ToString()));
        return WorkspaceSetting.ToDto();
    }
    [HttpGet]
    public WorkspaceSettingDto Get()
    {
        return service.Get().ToDto();
    }
}


