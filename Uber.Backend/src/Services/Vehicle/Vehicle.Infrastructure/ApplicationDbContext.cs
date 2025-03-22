using System.Reflection;
using Vehicle.Application.Data;
using Vehicle.Domain.Models.Vehicle;
using DriverVehicle = Vehicle.Domain.Models.Vehicle.Vehicle;

namespace Vehicle.Infrastructure;
public class ApplicationDbContext: DbContext,IApplicationDbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<DriverVehicle> Vehicles => Set<DriverVehicle>();

    public DbSet<AllVehicleModel> AllVehicles => Set<AllVehicleModel>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
