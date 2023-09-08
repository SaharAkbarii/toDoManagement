using TodoManagement.API.Model;
using TodoManagement.API.Repository;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TodoManagement.API.AppService;

public class PersonAppService: BaseAppService<Person>
{
    private readonly ToDoUpdateNotifier toDoUpdateNotifier;

    public PersonAppService(ToDoManagementDbContext dbContext,
        ToDoUpdateNotifier toDoUpdateNotifier)
        : base (dbContext)
    {
        this.toDoUpdateNotifier = toDoUpdateNotifier;
    }
    public Person Create(string name)
    {
        var person = new Person(name);
        dbContext.People.Add(person);
        dbContext.SaveChanges();

        var message = $"New Person with id:{person.Id}, Name: {person.Name} was created";
        toDoUpdateNotifier.SendNotification(message);

        return person;
    }


    public List<ToDo> GetAllToDosByPerson(Guid id)
    {
        var person = dbContext.People
            .AsNoTracking()
            .IncludeAllConnections()
            .FirstOrDefault(x => x.Id == id);
        return person.ToDos;
    }

    public SearchResult<Person> Search(string keyWord, int count, int offset)
    {
        var query = dbContext.People
            .AsNoTracking()
            .Where(x => x.Name.Contains(keyWord));

        var people = query
            .Skip(offset)
            .Take(count)
            .ToList();

        var totalCount = query
            .Count();

        var searchResult = new SearchResult<Person>(people, totalCount);
        return searchResult;
    }

    protected override IQueryable<Person> IncludeGetConnections(IQueryable<Person> collection)
    {
        return collection.IncludeAllConnections();
    }
    protected override IQueryable<Person> IncludeGetAllConnections(IQueryable<Person> collection)
    {
     return collection.IncludeAllConnections();
    }
}
