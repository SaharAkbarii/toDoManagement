using System.Text;
using System.Text.Json;
using TodoManagement.API.Model;

namespace TodoManagement.API.Infrastructure;

public class SlackMessageSender: IMessageSender
{
    public void Send(string slackWebHookUrl, string message)
    {
        HttpClient client = new HttpClient();
        using StringContent jsonContent = new(
        JsonSerializer.Serialize(new
        {
            text = message
        }),
        Encoding.UTF8,
        "application/json");

        using HttpResponseMessage response = client.PostAsync(
           slackWebHookUrl,
           jsonContent).Result;
    }

}

public class SmsSender : IMessageSender
{
    public void Send(string target, string body)
    {
        throw new NotImplementedException();
    }
}

public class EmailSender : IMessageSender
{
    public void Send(string target, string body)
    {
        throw new NotImplementedException();
    }
}
