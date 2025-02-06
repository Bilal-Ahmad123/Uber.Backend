
namespace Driver.Application.Vehicle.Commands.CreateVehicle;
public record CreateVehicleCommand(VehicleDto Vehicle):ICommand<CreateVehicleResult>;
public record CreateVehicleResult(Guid Id);
