using Vehicle.Application.Data;
using Vehicle.Application.Repositories;
using Vehicle.Application.Vehicle.Commands.RegisterNewVehicle;
using Vehicle.Domain.Models.Vehicle;
using DriverVehicle = Vehicle.Domain.Models.Vehicle.Vehicle;
namespace Vehicle.Infrastructure.Repository.Vehicle;
public class VehicleRepository(IApplicationDbContext dbContext) : IVehicleRepository
{
    public async Task<DriverVehicle> GetVehicleDetails(Guid driverId)
    {
       var vehicle =  await dbContext.Vehicles.FirstOrDefaultAsync(x => x.DriverId == driverId);

        if(vehicle is null)
        {
            throw new InvalidOperationException("Vehicle not found.");
        }
        return vehicle;
    }

    public async Task RegisterNewVehicle(AllVehicleModel vehicle,CancellationToken cancellationToken)
    {
        dbContext.AllVehicles.Add(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
