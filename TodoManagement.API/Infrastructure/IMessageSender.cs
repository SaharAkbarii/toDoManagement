namespace TodoManagement.API.Infrastructure;


public interface IMessageSender
{
    void Send(string target, string body);
}


