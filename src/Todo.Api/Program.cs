using Microsoft.EntityFrameworkCore;
using Todo.Data;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<ApplicationDBContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("TodoListDB"))
);

var app = builder.Build();

app.Run();