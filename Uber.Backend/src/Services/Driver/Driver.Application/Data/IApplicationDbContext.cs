using Microsoft.EntityFrameworkCore;
using DriverVehicle =  Driver.Domain.Models.Vehicle.Vehicle;
namespace Driver.Application.Data;

public interface IApplicationDbContext
{
    DbSet<DriverVehicle> Vehicles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
