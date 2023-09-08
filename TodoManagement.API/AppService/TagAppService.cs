using TodoManagement.API.Model;
using TodoManagement.API.Repository;

namespace TodoManagement.API.AppService;

public class TagAppService : BaseAppService<Tag>
{
    private readonly ToDoUpdateNotifier toDoUpdateNotifier;

    public TagAppService(ToDoManagementDbContext dbContext, 
        ToDoUpdateNotifier toDoUpdateNotifier) 
        : base(dbContext)
    {
        this.toDoUpdateNotifier = toDoUpdateNotifier;
    }

    public Tag GetOrCreate(string title)
    {
        var tag = dbContext.Tags.FirstOrDefault(x => x.Title == title);
        if (tag != null)
        {
            return tag;
        }

        tag = new Tag(title);
        dbContext.Tags.Add(tag);
        dbContext.SaveChanges();

        var message = $"New Tag with id:{tag.Id}, Title: {tag.Title} was created";

        toDoUpdateNotifier.SendNotification(message);
        return tag;
    }

    public void Remove(Guid id)
    {
        var tag = dbContext.Tags.FirstOrDefault(x => x.Id == id);
        dbContext.Tags.Remove(tag);
        dbContext.SaveChanges();
    }

    protected override IQueryable<Tag> IncludeGetAllConnections(IQueryable<Tag> collection) => collection;

    protected override IQueryable<Tag> IncludeGetConnections(IQueryable<Tag> collection) => collection;

}
