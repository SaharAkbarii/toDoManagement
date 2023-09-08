using TodoManagement.API.Model;
using TodoManagement.API.Repository;

namespace TodoManagement.API.AppService;

public abstract class BaseAppService<TEntity> where TEntity : Entity
{
    protected ToDoManagementDbContext dbContext;

    public BaseAppService(ToDoManagementDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public virtual TEntity Get(Guid id)
    {
        var result = IncludeGetConnections(dbContext.Set<TEntity>()).FindById(id);
        return result;
    }

    public virtual List<TEntity> GetAll()
    {
        var results = IncludeGetAllConnections(dbContext.Set<TEntity>()).ToList();
        return results;
    }

    public virtual void Delete(Guid id)
    {
        var result = dbContext.Set<TEntity>().FindById(id);
        dbContext.Set<TEntity>().Remove(result);
        dbContext.SaveChanges();
    }
    protected abstract IQueryable<TEntity> IncludeGetConnections(IQueryable<TEntity> collection);
    protected abstract IQueryable<TEntity> IncludeGetAllConnections(IQueryable<TEntity> collection);

}
