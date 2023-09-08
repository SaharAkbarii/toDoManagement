namespace TodoManagement.API.Model;

public class WorkspaceSetting : Entity
{
    public string? TargetNotificationAddress { get; set; }
    public NotificationChannel Channel { get; set; }
}

public enum NotificationChannel
{
    Slack,
    Sms,
    Email
}