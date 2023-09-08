using TodoManagement.API.Model;
using TodoManagement.API.Repository;
using Microsoft.EntityFrameworkCore;


namespace TodoManagement.API.AppService;

public class SprintAppService : BaseAppService<Sprint>
{
    private readonly ToDoUpdateNotifier toDoUpdateNotifier;

    public SprintAppService(ToDoManagementDbContext dbContext,
        ToDoUpdateNotifier toDoUpdateNotifier)
        : base(dbContext)
    {
        this.toDoUpdateNotifier = toDoUpdateNotifier;
    }

    public Sprint Create(string name, DateTimeOffset startDate, DateTimeOffset endDate)
    {
        var sprint = new Sprint(name, startDate, endDate);
        dbContext.Sprints.Add(sprint);
        dbContext.SaveChanges();

        var message = $"New Sprint with id:{sprint.Id}, Name: {sprint.Name} was created";
        toDoUpdateNotifier.SendNotification(message);

        return sprint;
    }

    public Sprint Update(Guid id, string name, DateTimeOffset startDate, DateTimeOffset endDate)
    {
        var sprint = dbContext.Sprints.FindById(id);
        sprint.Name = name;
        sprint.StartDate = startDate;
        sprint.EndDate = endDate;
        dbContext.SaveChanges();

        var message = $"Sprint with id:{sprint.EndDate} was updated. \r\n Currently is such as the following: \r\n Name : {sprint.Name} \r\n StartDate: {sprint.StartDate} \r\n EndDate: {sprint.EndDate}";
        toDoUpdateNotifier.SendNotification(message);

        return sprint;
    }

    public override void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    protected override IQueryable<Sprint> IncludeGetAllConnections(IQueryable<Sprint> collection)
    {
        return collection.IncludeAllConnections();
    }

    protected override IQueryable<Sprint> IncludeGetConnections(IQueryable<Sprint> collection)
    {
        return collection.IncludeAllConnections();
    }
}
