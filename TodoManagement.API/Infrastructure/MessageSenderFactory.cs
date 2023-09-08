using TodoManagement.API.Model;

namespace TodoManagement.API.Infrastructure;

public static class MessageSenderFactory
{
    public static IMessageSender Create(WorkspaceSetting setting)  
    {
        switch (setting.Channel)
        {
            case NotificationChannel.Email:
                return new EmailSender();
            
            case NotificationChannel.Slack:
                return new SlackMessageSender();

            case NotificationChannel.Sms:
                return new SmsSender();

            default:
                throw new ArgumentException();
        }
    }
}