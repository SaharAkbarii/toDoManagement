using Microsoft.EntityFrameworkCore;
using TodoManagement.API.Repository;
using TodoManagement.API.AppService;
using TodoManagement.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoManagementDbContext>(b =>
            {
                string connectionString = builder.Configuration.GetValue<string>("ConnectionStrings");
                b.UseNpgsql(connectionString);
            });
builder.Services.AddAutoMapper(typeof(ToDoAppService).Assembly);
builder.Services.AddScoped<PersonAppService>();
builder.Services.AddScoped<ToDoAppService>();
builder.Services.AddScoped<ProjectAppService>();
builder.Services.AddScoped<TagAppService>();
builder.Services.AddScoped<WorkspaceSettingAppService>();
builder.Services.AddSingleton<SlackMessageSender>();
builder.Services.AddScoped<SprintAppService>();
builder.Services.AddScoped<ToDoUpdateNotifier>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "sahar",
                      policy  =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
});

var app = builder.Build();
app.UseCors("sahar");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
