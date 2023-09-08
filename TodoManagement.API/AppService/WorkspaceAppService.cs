using TodoManagement.API.Model;
using TodoManagement.API.Repository;

namespace TodoManagement.API.AppService;

public class WorkspaceSettingAppService : BaseAppService<WorkspaceSetting>
{

    public WorkspaceSettingAppService(ToDoManagementDbContext dbContext) 
        : base(dbContext)
    {
    }

    public WorkspaceSetting Update(string targetAddress, NotificationChannel channel)
    {
        var settings = dbContext.WorkspaceSettings.FirstOrDefault();
        if (settings != null)
        {
            settings.Channel = channel;
            settings.TargetNotificationAddress = targetAddress;
        }

        else
        {
            settings = new WorkspaceSetting();
            settings.Channel = channel;
            settings.TargetNotificationAddress = targetAddress;
            dbContext.WorkspaceSettings.Add(settings);
        }

        dbContext.SaveChanges();
        return settings;

    }
    public WorkspaceSetting Get()
    {
        var settings = dbContext.WorkspaceSettings.FirstOrDefault();
        if (settings != null)
            return settings;

        return new WorkspaceSetting();
    }

    public override List<WorkspaceSetting> GetAll()
    {
        throw new NotImplementedException();
    }

    public override void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public override WorkspaceSetting Get(Guid id)
    {
        throw new NotImplementedException();
    }
    protected override IQueryable<WorkspaceSetting> IncludeGetConnections(IQueryable<WorkspaceSetting> collection)
    {
        throw new NotImplementedException();
    }

    protected override IQueryable<WorkspaceSetting> IncludeGetAllConnections(IQueryable<WorkspaceSetting> collection)
    {
        throw new NotImplementedException();
    }
}
