using System.Reflection;
using Driver.Application.Data;
using Driver.Domain.Models.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace Driver.Infrastructure;
public class ApplicationDbContext: DbContext,IApplicationDbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
