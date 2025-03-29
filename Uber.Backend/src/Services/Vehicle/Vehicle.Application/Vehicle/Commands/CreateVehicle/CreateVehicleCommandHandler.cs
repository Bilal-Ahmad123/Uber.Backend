using Vehicle.Application.Data;
using Vehicle.Application.Repositories;
using DriverVehicle = Vehicle.Domain.Models.Vehicle.Vehicle;
namespace Vehicle.Application.Vehicle.Commands.CreateVehicle;
public class CreateVehicleCommandHandler(IVehicleRepository vehicleRepository) : ICommandHandler<CreateVehicleCommand, CreateVehicleResult>
{
    public Task<CreateVehicleResult> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = CreateVehicle(request.Vehicle);
        vehicleRepository.CreateDriverVehicle(vehicle,cancellationToken);
        return Task.FromResult(new CreateVehicleResult(vehicle.Id));
    }

    public DriverVehicle CreateVehicle(VehicleDto vehicle)
    {
        var vehicleReq = DriverVehicle.Create(
            vehicle.DriverId,
            vehicle.VehicleMake,
            vehicle.VehicleModel,
            vehicle.VehicleYear,
            vehicle.VehicleColor,
            vehicle.VehiclePlateNumber,
            vehicle.VehicleType
            );
        return vehicleReq;
    }
}
