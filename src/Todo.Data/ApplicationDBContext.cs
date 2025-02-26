using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Todo.Data;

namespace Todo.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :
        base(options) { }

    protected override void OnModelCreating(ModelBuilder builer)
    {
        base.OnModelCreating(builer);

        builer.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly()
        );
    }
}