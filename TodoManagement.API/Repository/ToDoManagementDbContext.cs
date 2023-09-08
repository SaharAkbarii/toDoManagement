using Microsoft.EntityFrameworkCore;
using TodoManagement.API.Model;

namespace TodoManagement.API.Repository;

public class ToDoManagementDbContext : DbContext
{
    public ToDoManagementDbContext(DbContextOptions options)
       : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>().HasOne(x => x.Assignee).WithMany(x => x.ToDos).IsRequired(false);
        modelBuilder.Entity<Project>().Ignore(x => x.ProgressPercent);
        modelBuilder.Entity<Project>().Ignore(x => x.DeadLineState);
        modelBuilder.Entity<ToDo>().HasMany(x => x.RelatedTodos).WithOne(x => x.ToDo);
        modelBuilder.Entity<RelatedTodo>().HasOne(x => x.RelatedToDo);

    }


    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<ChangeTodoStatusHistory> ChangeTodoStatusHistories { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<CheckListItem> CheckListItems { get; set; }
    public DbSet<RelatedTodo> RelatedTodos { get; set; }
    public DbSet <Tag> Tags {get; set;}
    public DbSet <TagToDo> TagToDos { get; set; }
    public DbSet <WorkspaceSetting> WorkspaceSettings {get; set;}
    public DbSet<Sprint> Sprints { get; set; }
}
