namespace TodoManagement.API.Model;

public class Person : Entity
{
    public Person(string name)
    {
        ToDos = new List<ToDo>();
        Name = name;
    }

    public string Name { get; set; }
    public List<ToDo> ToDos { get; set; }


}
