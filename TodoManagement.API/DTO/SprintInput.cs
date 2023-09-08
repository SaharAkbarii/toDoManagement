using TodoManagement.API.Model;

namespace TodoManagement.API.DTO;

public class SprintInput
{
    public string Name{get; set;}
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}
public class CreateSprintInput : SprintInput
{

}
public class UpdateSprintInput : SprintInput
{

}