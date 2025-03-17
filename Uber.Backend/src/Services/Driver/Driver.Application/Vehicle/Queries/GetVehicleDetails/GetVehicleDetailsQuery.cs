using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Application.Vehicle.Queries.GetVehicleDetails;
public record GetVehicleDetailsQuery(Guid DriverId):IQuery<GetVehicleDetailsResult>;

public record GetVehicleDetailsResult(
    string VehicleMake,
    string VehicleModel,
    string VehicleYear,
    string VehicleColor,
    string VehiclePlateNumber,
    string VehicleType
);
