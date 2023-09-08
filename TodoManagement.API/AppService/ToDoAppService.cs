using TodoManagement.API.Model;
using TodoManagement.API.Repository;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoManagement.API.Exceptions;
using System.Text.Json;
using System.Text;
using TodoManagement.API.Infrastructure;

namespace TodoManagement.API.AppService;
public class ToDoAppService : BaseAppService<ToDo>
{
    private TagAppService tagService;
    private WorkspaceSettingAppService workspaceSettingAppService;
    private readonly ToDoUpdateNotifier toDoUpdateNotifier;

    public ToDoAppService(
        ToDoManagementDbContext dbContext,
        TagAppService tagService,
        WorkspaceSettingAppService workspaceSettingAppService,
        ToDoUpdateNotifier toDoUpdateNotifier)

        : base(dbContext)
    {
        this.tagService = tagService;
        this.workspaceSettingAppService = workspaceSettingAppService;
        this.toDoUpdateNotifier = toDoUpdateNotifier;
    }


    public ToDo Create(string title, string description, Guid? projectId, int storyPoint, Guid? sprintId)
    {
        var toDo = new ToDo(title, description);
        if (projectId.HasValue)
        {
            var project = dbContext.Projects.FindById(projectId.Value);
            toDo.Project = project;
        }
        toDo.StoryPoint = storyPoint;
        if (sprintId.HasValue)
        {
            var sprint = dbContext.Sprints.FindById(sprintId.Value);
            toDo.Sprint = sprint;
        }

        dbContext.ToDos.Add(toDo);
        dbContext.SaveChanges();

        var message = $"New ToDo with id:{toDo.Id}, Title: {toDo.Title} was created";

        toDoUpdateNotifier.SendNotification(message);

        return toDo;
    }

    public ToDo Update(Guid id, string title, string description, Guid? projectId, int storyPoint, Guid? sprintId)
    {
        var toDo = dbContext.ToDos.Include(x => x.Project).Include(x => x.Sprint).FindById(id);

        toDo.Title = title;
        toDo.Description = description;
        if (projectId.HasValue)
        {
            var project = dbContext.Projects.FindById(projectId.Value);
            toDo.Project = project;
        }
        else
            toDo.Project = null;

        toDo.StoryPoint = storyPoint;
        if (sprintId.HasValue)
        {
            var sprint = dbContext.Sprints.FindById(sprintId.Value);
            toDo.Sprint = sprint;
        }
        else
            toDo.Sprint = null;

        dbContext.SaveChanges();
        var message = $"Todo with id:{toDo.Id} was updated. \r\n Currently is such as the following: \r\n Name : {toDo.Title} \r\n Description: {toDo.Description}";

        toDoUpdateNotifier.SendNotification(message);

        return toDo;
    }

    public ToDo UpdateStatus(Guid id, ToDoStatus status)
    {
        var toDo = dbContext.ToDos.Include(x => x.ChangeTodoStatusHistories).FirstOrDefault(x => x.Id == id);
        var oldStatus = toDo.Status;
        toDo.ChangeStatus(status);
        var history = new ChangeTodoStatusHistory(status, toDo);
        dbContext.ChangeTodoStatusHistories.Add(history);
        dbContext.SaveChanges();

        SendChangeStatuesNotification(toDo, oldStatus);
        return toDo;

    }

    public ToDo Assign(Guid toDoId, Guid personId)
    {
        var toDo = dbContext.ToDos.FirstOrDefault(x => x.Id == toDoId);
        var person = dbContext.People.FirstOrDefault(x => x.Id == personId);
        toDo.Assign(person);
        dbContext.SaveChanges();
        return toDo;
    }

    public ToDo Approved(Guid toDoId, Guid personId)
    {
        var toDo = dbContext.ToDos.FirstOrDefault(x => x.Id == toDoId);
        var person = dbContext.People.FirstOrDefault(x => x.Id == personId);
        toDo.Approve(person);
        dbContext.SaveChanges();
        return toDo;
    }

    public CheckListItem AddCheckListItem(Guid toDoId, string title, bool isChecked)
    {
        var toDo = dbContext.ToDos.FirstOrDefault(x => x.Id == toDoId) ??
            throw new ResourceNotFoundException($"Todo with {toDoId} not found.");

        var checkListItem = new CheckListItem(title, toDo);
        checkListItem.IsChecked = isChecked;
        toDo.AddCheckListItem(checkListItem);
        dbContext.CheckListItems.Add(checkListItem);
        dbContext.SaveChanges();
        return checkListItem;
    }

    public CheckListItem UpdateCheckListItem(Guid toDoId, Guid checkListId, string title, bool isChecked)
    {
        var toDo = dbContext.ToDos.Include(x => x.CheckList).FirstOrDefault(x => x.Id == toDoId) ??
            throw new ResourceNotFoundException($"Todo with {toDoId} not found.");

        var checkListItem = toDo.CheckList.FirstOrDefault(x => x.Id == checkListId) ??
            throw new ResourceNotFoundException($"checklist item with {checkListId} not found.");

        checkListItem.Title = title;
        checkListItem.IsChecked = isChecked;
        dbContext.SaveChanges();
        return checkListItem;
    }

    public void RemoveCheckListItem(Guid checkListId)
    {
        var checkListItem = dbContext.CheckListItems.FirstOrDefault(x => x.Id == checkListId) ??
            throw new ResourceNotFoundException($"checklist item with {checkListId} not found.");

        dbContext.CheckListItems.Remove(checkListItem);
        dbContext.SaveChanges();
    }

    public ToDo AddRelatedTodo(Guid mainTodoId, Guid secondTodoId, RelationStatus relationStatus)
    {
        var mainTodo = dbContext.ToDos.FirstOrDefault(x => x.Id == mainTodoId);
        var secondTodo = dbContext.ToDos.FirstOrDefault(x => x.Id == secondTodoId);
        var relation = new RelatedTodo(mainTodo, secondTodo, relationStatus);
        mainTodo.AddRelatedTodos(relation);
        dbContext.RelatedTodos.Add(relation);
        dbContext.SaveChanges();
        return mainTodo;
    }

    public void RemoveRelatedTodo(Guid mainTodoId, Guid relationId)
    {
        var mainTodo = dbContext.ToDos
            .Include(x => x.RelatedTodos)
            .FirstOrDefault(x => x.Id == mainTodoId) ??
            throw new ResourceNotFoundException($"Todo with {mainTodoId} not found.");

        mainTodo.RemoveRelatedTodo(relationId);
        dbContext.SaveChanges();
    }

    public SearchResult<ToDo> Search(string keyWord, int count, int offset)
    {
        IQueryable<ToDo> query = dbContext.ToDos.AsNoTracking()
            .Where(x => x.Title.Contains(keyWord) || x.Description.Contains(keyWord));

        var toDos = query
            .Skip(offset)
            .Take(count)
            .ToList();

        var totalCount = query
            .Count();

        var searchResult = new SearchResult<ToDo>(toDos, totalCount);
        return searchResult;
    }

    public ToDo AddTag(Guid id, string title)
    {
        var toDo = dbContext.ToDos.FirstOrDefault(x => x.Id == id);
        var tag = tagService.GetOrCreate(title);
        var tagToDo = new TagToDo(toDo, tag);
        toDo.AddTags(tagToDo);
        dbContext.TagToDos.Add(tagToDo);
        dbContext.SaveChanges();
        return toDo;
    }
    public List<ToDo> SearchByTags(List<Guid> tagIds)
    {
        var toDos = dbContext.TagToDos.Where(x=> tagIds.Any(y=> y== x.Tag.Id)).Select(x=> x.ToDo).Distinct().ToList();
        return toDos;
    }

    protected override IQueryable<ToDo> IncludeGetConnections(IQueryable<ToDo> Collection)
    {
        return Collection
        .IncludeAllConnections();
    }
    protected override IQueryable<ToDo> IncludeGetAllConnections(IQueryable<ToDo> Collection)
    {
        return Collection
        .IncludeAllConnections();
    }

    private void SendChangeStatuesNotification(ToDo toDo, ToDoStatus oldStatus)
    {
        var setting = workspaceSettingAppService.Get();
        if (setting.TargetNotificationAddress != null)
        {
            var text = $"{toDo.Title} \r\n{toDo.Description} \r\nStatus changed From:{oldStatus} to {toDo.Status}";
            var sender = MessageSenderFactory.Create(setting);
            sender.Send(setting.TargetNotificationAddress, text);
        }
    }

}