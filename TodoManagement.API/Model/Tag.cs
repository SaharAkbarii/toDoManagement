namespace TodoManagement.API.Model;

public class Tag : Entity
{
    protected Tag()
    {

    }

    public Tag(string title)
    {
        Title = title;
    }

    public string Title {get; set;}
}
