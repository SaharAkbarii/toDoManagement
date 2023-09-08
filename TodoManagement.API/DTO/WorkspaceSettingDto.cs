namespace TodoManagement.API.DTO;

public class WorkspaceSettingDto
{
    public string? TargetNotificationAddress { get; set; }
    public Guid Id { get; set; }
    public NotificationChannelDto Channel { get; set; }
}

public enum NotificationChannelDto
{
    Slack,
    Sms,
    Email
}