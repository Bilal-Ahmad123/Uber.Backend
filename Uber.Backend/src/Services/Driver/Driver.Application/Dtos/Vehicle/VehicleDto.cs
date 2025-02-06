

namespace Driver.Application.Dtos.Vehicle;
public record VehicleDto
(
    Guid DriverId,
    string VehicleType,
    string VehicleModel,
    DateTime VehicleYear,
    string VehiclePlateNumber,
    string VehicleColor,
    string VehicleMake
);

