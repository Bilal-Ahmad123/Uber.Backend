using Vehicle.Application.Data;
using DriverVehicle = Vehicle.Domain.Models.Vehicle.Vehicle;
namespace Vehicle.Application.Vehicle.Commands.CreateVehicle;
public class CreateVehicleCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateVehicleCommand, CreateVehicleResult>
{
    public async Task<CreateVehicleResult> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = CreateVehicle(request.Vehicle);
        dbContext.Vehicles.Add(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateVehicleResult(vehicle.AllVehicleModel.Id.Value);
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
