using Microsoft.EntityFrameworkCore;
using DriverVehicle =  Driver.Domain.Models.Vehicle.Vehicle;
using DriverModel = Driver.Domain.Models.Driver.Driver;
namespace Driver.Application.Data;

public interface IApplicationDbContext
{
    DbSet<DriverVehicle> Vehicles { get; }
    DbSet<DriverModel> Drivers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
