using TodoManagement.API.Model;

namespace TodoManagement.API.DTO;
public class ProjectDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<TodoDto>? ToDos { get; set; }
    public Guid Id { get; set; }
    public int ProgressPercent { get; set; }
    public DateTimeOffset? DeadLine {get; set;}
    public DeadLineState DeadLineState {get; set;}

}
