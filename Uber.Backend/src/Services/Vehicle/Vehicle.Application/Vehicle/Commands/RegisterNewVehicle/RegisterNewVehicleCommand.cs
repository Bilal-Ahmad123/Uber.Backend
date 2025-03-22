using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Application.Vehicle.Commands.RegisterNewVehicle;
public record RegisterNewVehicleCommand(
    string VehicleName,
    int MaxSeats,
    decimal BaseFare,
    decimal RatePerKM,
    string ImageUrl
):ICommand<RegisterNewVehicleCommandResult>;

public record RegisterNewVehicleCommandResult(
    Guid VehicleId
);
