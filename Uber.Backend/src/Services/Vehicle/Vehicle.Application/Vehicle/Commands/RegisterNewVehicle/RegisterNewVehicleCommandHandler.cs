using Vehicle.Application.Repositories;
using Vehicle.Application.Services;
using Vehicle.Domain.Models.Vehicle;
using Vehicle.Domain.ValueObjects;

namespace Vehicle.Application.Vehicle.Commands.RegisterNewVehicle;
public class RegisterNewVehicleCommandHandler(IAllVehiclesRepository repository,IFileService fileService) : ICommandHandler<RegisterNewVehicleCommand, RegisterNewVehicleCommandResult>
{
    public async Task<RegisterNewVehicleCommandResult> Handle(RegisterNewVehicleCommand request, CancellationToken cancellationToken)
    {
        var filePath = await fileService.SaveFileAsync(request.ImageUrl);
        var vehicle = MapToAllVehicleModel(request, filePath);
        await repository.RegisterNewVehicle(vehicle,cancellationToken);
        return new RegisterNewVehicleCommandResult(vehicle.Id.Value);
    }

    private AllVehicleModel MapToAllVehicleModel(RegisterNewVehicleCommand command, string filePath)
    {
        return new AllVehicleModel
        {
            Id = VehicleId.Of(Guid.NewGuid()),
            VehicleName = command.VehicleName,
            BaseFare = command.BaseFare,
            RatePerKM = command.RatePerKM,
            MaxSeats = command.MaxSeats,
            ImageUrl = filePath,
            VehicleDescription = command.VehicleDescription
        };
    }
}
