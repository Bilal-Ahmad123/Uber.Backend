using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Application.Repositories;
using Vehicle.Domain.Models.Vehicle;
using Vehicle.Domain.ValueObjects;

namespace Vehicle.Application.Vehicle.Commands.RegisterNewVehicle;
public class RegisterNewVehicleCommandHandler(IVehicleRepository repository) : ICommandHandler<RegisterNewVehicleCommand, RegisterNewVehicleCommandResult>
{
    public async Task<RegisterNewVehicleCommandResult> Handle(RegisterNewVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = MapToAllVehicleModel(request);
        await repository.RegisterNewVehicle(vehicle,cancellationToken);
        return new RegisterNewVehicleCommandResult(vehicle.Id.Value);
    }

    private AllVehicleModel MapToAllVehicleModel(RegisterNewVehicleCommand command)
    {
        return new AllVehicleModel
        {
            Id = VehicleId.Of(Guid.NewGuid()),
            VehicleName = command.VehicleName,
            BaseFare = command.BaseFare,
            RatePerKM = command.RatePerKM,
            MaxSeats = command.MaxSeats,
            ImageUrl = command.ImageUrl
        };
    }
}
