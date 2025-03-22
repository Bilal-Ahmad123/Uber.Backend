

namespace Vehicle.Application.Vehicle.Queries.GetVehicleDetails;
public record GetVehicleDetailsQuery(Guid DriverId):IQuery<GetVehicleDetailsResult>;

public record GetVehicleDetailsResult(
    string VehicleMake,
    string VehicleModel,
    string VehicleYear,
    string VehicleColor,
    string VehiclePlateNumber,
    string VehicleType
);
