namespace TodoManagement.API.DTO;

public class UpdateWorkspaceSettingInput
{
    public string? TargetNotificationAddress {get; set;}
    public  NotificationChannelDto Channel { get; set; }
}