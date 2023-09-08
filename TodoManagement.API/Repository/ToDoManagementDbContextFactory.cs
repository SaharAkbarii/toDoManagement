using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TodoManagement.API.Repository;

public class ToDoManagementDbContextFactory
        : IDesignTimeDbContextFactory<ToDoManagementDbContext>
{
    public ToDoManagementDbContext CreateDbContext(string[] args)
    {
        // string cs = Environment.GetEnvironmentVariable("SAMANTHA_CONNECTIONSTRING");
        string cs = "User ID=ocirptrg;Password=L0d-XwBR2O5wh0I-5kmUbzmo4qnZBU6w;Host=lallah.db.elephantsql.com;Port=5432;Database=ocirptrg;";


        if (cs == null)
            throw new InvalidOperationException("Provide connection string via SAMANTHA_CONNECTIONSTRING env var");

        DbContextOptions<ToDoManagementDbContext> options
            = new DbContextOptionsBuilder<ToDoManagementDbContext>()
                .UseNpgsql(cs)
                .Options;

        return new ToDoManagementDbContext(options);
    }
}
