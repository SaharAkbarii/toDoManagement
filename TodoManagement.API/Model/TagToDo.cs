namespace TodoManagement.API.Model;

public class TagToDo : Entity
{
    protected TagToDo()
    {

    }
    public TagToDo(ToDo toDo, Tag tag)
    {
        ToDo = toDo;
        Tag = tag;
    }

    public ToDo ToDo { get; set; }
    public Tag Tag { get; set; }
}
