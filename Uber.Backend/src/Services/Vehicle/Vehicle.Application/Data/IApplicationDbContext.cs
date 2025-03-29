using Microsoft.EntityFrameworkCore;
using Vehicle.Domain.Models.Vehicle;
using DriverVehicle = Vehicle.Domain.Models.Vehicle.Vehicle;
namespace Vehicle.Application.Data;

public interface IApplicationDbContext : IDisposable
{
    DbSet<AllVehicleModel> AllVehicles { get; }
    DbSet<DriverVehicle> Vehicles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
