using Microsoft.EntityFrameworkCore;
using TodoManagement.API.Exceptions;
using TodoManagement.API.Model;

namespace TodoManagement.API.Repository;

public static class EntityExtension
{
    public static T FindById<T>(this IQueryable<T> data, Guid id) where T : Entity
    {
        var t = data.FirstOrDefault(x => x.Id == id) ??
            throw new ResourceNotFoundException($"{typeof(T)} with {id} not found.");

        return t;
    }
    public static IQueryable<ToDo> IncludeAllConnections(this IQueryable<ToDo> data)
        => data.Include(x => x.Project)
            .Include(x => x.ApprovedBy)
            .Include(x => x.Assignee)
            .Include(x => x.CheckList)
            .Include(x => x.RelatedTodos)
            .Include(x => x.Sprint);

    public static IQueryable<Project> IncludeAllConnections(this IQueryable<Project> data)
        => data.Include(x => x.ToDos)
                .ThenInclude(x => x.ApprovedBy)
                .Include(x => x.ToDos)
                .ThenInclude(x => x.CheckList)
                .Include(x => x.ToDos)
                .ThenInclude(x => x.RelatedTodos)
                .Include(x => x.ToDos)
                .ThenInclude(x => x.Tags)
                .Include(x => x.ToDos)
                .ThenInclude(x => x.Sprint);

    public static IQueryable<Person> IncludeAllConnections(this IQueryable<Person> data)
        => data.Include(x => x.ToDos)
            .ThenInclude(x=> x.ApprovedBy)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.CheckList)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.Project)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.RelatedTodos)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.Tags)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.Sprint);

    public static IQueryable<Sprint> IncludeAllConnections(this IQueryable<Sprint> data)
        => data.Include(x => x.ToDos)
            .ThenInclude(x=> x.ApprovedBy)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.CheckList)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.Project)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.RelatedTodos)
            .Include(x => x.ToDos)
            .ThenInclude(x=> x.Tags);
          
}


