namespace TodoManagement.API.DTO;

public class ProjectInput
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? DeadLine { get; set; }
}

public class CreateProjectInput : ProjectInput
{
}

public class UpdateProjectInput : ProjectInput
{
}
