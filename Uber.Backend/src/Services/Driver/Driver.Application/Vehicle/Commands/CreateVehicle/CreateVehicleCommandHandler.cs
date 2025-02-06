using Driver.Application.Data;
using Driver.Domain.Models.Vehicle;
using Driver.Domain.ValueObjects;
using DriverVehicle = Driver.Domain.Models.Vehicle.Vehicle;
namespace Driver.Application.Vehicle.Commands.CreateVehicle;
public class CreateVehicleCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateVehicleCommand, CreateVehicleResult>
{
    public async Task<CreateVehicleResult> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = CreateVehicle(request.Vehicle);
        dbContext.Vehicles.Add(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateVehicleResult(vehicle.Id.Value);
    }

    public DriverVehicle CreateVehicle(VehicleDto vehicle)
    {
        var vehicleReq = DriverVehicle.Create(
            VehicleId.Of(Guid.NewGuid()),
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
