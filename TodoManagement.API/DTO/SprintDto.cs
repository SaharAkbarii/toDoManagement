namespace TodoManagement.API.DTO;

public class SprintDto
{
     public string Name { get; set; }
     public DateTimeOffset StartDate { get; set; }
     public DateTimeOffset EndDate { get; set; }
     public Guid Id { get; set; }
     public List<TodoDto> ToDos {get; set;}
}
