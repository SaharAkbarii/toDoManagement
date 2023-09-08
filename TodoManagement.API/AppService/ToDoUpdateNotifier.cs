using TodoManagement.API.Infrastructure;
using TodoManagement.API.Model;

namespace TodoManagement.API.AppService;

public class ToDoUpdateNotifier
{
    private WorkspaceSettingAppService workspaceSettingAppService;
    public ToDoUpdateNotifier(
        WorkspaceSettingAppService workspaceSettingAppService)
    {
        this.workspaceSettingAppService = workspaceSettingAppService;
    }
    public void SendNotification(string message)
    {
        var setting = workspaceSettingAppService.Get();
        if (setting.TargetNotificationAddress != null)
        {
            var sender = MessageSenderFactory.Create(setting);
            sender.Send(setting.TargetNotificationAddress, message);
        }
    }
}
