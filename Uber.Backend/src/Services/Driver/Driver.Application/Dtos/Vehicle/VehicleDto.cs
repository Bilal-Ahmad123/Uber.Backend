

namespace Driver.Application.Dtos.Vehicle;
public record VehicleDto
(
    Guid Id,
    string VehicleType,
    string VehicleModel,
    DateTime VehicleYear,
    string VehiclePlateNumber,
    string VehicleColor,
    string VehicleMake
);

