namespace TodoManagement.API.DTO;
public class PersonDto
{
    public string Name { get; set; }
    public List<TodoDto> Todos { get; set; }
    public Guid Id {get; set;}
}

