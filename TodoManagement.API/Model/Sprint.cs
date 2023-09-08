namespace TodoManagement.API.Model;

public class Sprint : Entity
{
    public Sprint(string name, DateTimeOffset startDate, DateTimeOffset endDate)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        ToDos= new List<ToDo>();
    }

    public string Name { get; set; }    
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public List<ToDo> ToDos { get; set; }

}
