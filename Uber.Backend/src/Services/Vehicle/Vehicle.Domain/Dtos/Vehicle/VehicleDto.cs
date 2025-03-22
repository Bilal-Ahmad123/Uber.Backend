

namespace Vehicle.Domain.Dtos.Vehicle;
public record VehicleDto
(
    Guid DriverId,
    string VehicleType,
    string VehicleModel,
    string VehicleYear,
    string VehiclePlateNumber,
    string VehicleColor,
    string VehicleMake
);

