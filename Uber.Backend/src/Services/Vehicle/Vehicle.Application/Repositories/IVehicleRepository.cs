
using Vehicle.Domain.Models.Vehicle;
using VehicleModel = Vehicle.Domain.Models.Vehicle.Vehicle;

namespace Vehicle.Application.Repositories;
public interface IVehicleRepository
{
    Task<VehicleModel> GetVehicleDetails(Guid driverId);
    Task RegisterNewVehicle(AllVehicleModel vehicleModel,CancellationToken cancellationToken);
    Task<List<AllVehicleDto>> GetNearbyVehicleDetails(IList<Guid> driverIds);
}
