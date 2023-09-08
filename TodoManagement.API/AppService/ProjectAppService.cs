using TodoManagement.API.Model;
using TodoManagement.API.Repository;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TodoManagement.API.AppService;

public class ProjectAppService : BaseAppService<Project>
{
    private readonly ToDoUpdateNotifier toDoUpdateNotifier;

    public ProjectAppService(ToDoManagementDbContext dbContext,
        ToDoUpdateNotifier toDoUpdateNotifier)
        : base(dbContext)
    {
        this.toDoUpdateNotifier = toDoUpdateNotifier;
    }

    public Project Create(string name, string description, DateTimeOffset? deadLine)
    {
        var project = new Project(name, description);
        project.DeadLine = deadLine;
        dbContext.Projects.Add(project);
        dbContext.SaveChanges();

        var message = $"New Project with id:{project.Id}, Name: {project.Name} was created";
        toDoUpdateNotifier.SendNotification(message);

        return project;
    }

    public Project Update(Guid id, string name, string description, DateTimeOffset? deadLine)
    {
        var project = dbContext.Projects
            .FirstOrDefault(x => x.Id == id);
        project.Name = name;
        project.Description = description;
        project.DeadLine = deadLine;
        dbContext.SaveChanges();

        var message = $"Project with id:{project.Id} was updated. \r\n Currently is such as the following: \r\n Name : {project.Name} \r\n StartDate: {project.Description} \r\n Deadline: {project.DeadLine}";
        toDoUpdateNotifier.SendNotification(message);

        return project;
    }

    public void Delete(Guid id)
    {
        var project = dbContext.Projects.FirstOrDefault(x => x.Id == id);
        dbContext.Projects.Remove(project);
        dbContext.SaveChanges();
    }

    public SearchResult<Project> Search(string keyWord, int count, int offset)
    {
        var projects = dbContext.Projects
            .AsNoTracking()
            .Include(x=> x.ToDos)
            .Where(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord))
            .Skip(offset)
            .Take(count)
            .ToList();

        var totalCount = dbContext.Projects
            .Where(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord))
            .Count();

        var searchResult = new SearchResult<Project>(projects, totalCount);
        return searchResult;
    }

    protected override IQueryable<Project> IncludeGetConnections(IQueryable<Project> collection)
    {
        return collection.IncludeAllConnections();
    }
    protected override IQueryable<Project> IncludeGetAllConnections(IQueryable<Project> collection)
    {
        return collection.IncludeAllConnections();
    }
}
