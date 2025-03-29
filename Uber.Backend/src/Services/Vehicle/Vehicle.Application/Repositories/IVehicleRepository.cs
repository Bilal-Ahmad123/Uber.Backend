using VehicleModel = Vehicle.Domain.Models.Vehicle.Vehicle;
using DriverVehicle = Vehicle.Domain.Models.Vehicle.Vehicle;

namespace Vehicle.Application.Repositories;
public interface IVehicleRepository
{
    Task<VehicleModel> GetVehicleDetails(Guid driverId);
    Task<List<AllVehicleDto>> GetNearbyVehicleDetails(IList<Guid> driverIds);
    Task CreateDriverVehicle(DriverVehicle driverVehicle,CancellationToken cancellationToken);
}
