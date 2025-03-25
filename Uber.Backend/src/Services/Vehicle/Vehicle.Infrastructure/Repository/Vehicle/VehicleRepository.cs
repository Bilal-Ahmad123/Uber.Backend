using Vehicle.Application.Data;
using Vehicle.Application.Repositories;
using Vehicle.Application.Vehicle.Commands.RegisterNewVehicle;
using Vehicle.Domain.Dtos.Vehicle;
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

    public Task<List<AllVehicleDto>> GetNearbyVehicleDetails(IList<Guid> driverIds)
    {
        var vehicles = dbContext.Vehicles.Where(v => driverIds.Contains(v.Id))
            .Include(v => v.AllVehicleModel)
            .Select(v => new AllVehicleDto
            (
                v.AllVehicleModel.VehicleName,
                v.AllVehicleModel.MaxSeats,
                v.AllVehicleModel.BaseFare,
                v.AllVehicleModel.RatePerKM,
                v.AllVehicleModel.ImageUrl
            )).ToListAsync();

        return vehicles;
    }

}
