
using Mapster;
using Vehicle.Application.Repositories;

namespace Vehicle.Application.Vehicle.Queries.GetVehicleDetails;
public class GetVehicleDetailsHandler(IVehicleRepository vehicleRepository) : IQueryHandler<GetVehicleDetailsQuery, GetVehicleDetailsResult>
{
    public Task<GetVehicleDetailsResult> Handle(GetVehicleDetailsQuery request, CancellationToken cancellationToken)
    {
        var vehicle = vehicleRepository.GetVehicleDetails(request.DriverId);
        return Task.FromResult(vehicle.Result.Adapt<GetVehicleDetailsResult>());
    }
}
