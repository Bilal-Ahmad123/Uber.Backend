using System.Reflection;
using Driver.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Driver.Infrastructure;
public class ApplicationDbContext: DbContext,IApplicationDbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Driver.Domain.Models.Driver.Driver> Drivers => Set<Driver.Domain.Models.Driver.Driver>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
