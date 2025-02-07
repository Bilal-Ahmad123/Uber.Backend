
using Driver.Domain.ValueObjects;

namespace Driver.Domain.Models.Vehicle;
public class Vehicle:Entity<VehicleId>
{
    public string VehicleMake { get; private set; } = default!;
    public string VehicleModel { get; private set; } = default!;
    public string VehicleYear { get; private set; } = default!;
    public string VehicleColor { get; private set; } = default!;
    public string VehiclePlateNumber { get; private set; } = default!;
    public string VehicleType { get; private set; } = default!;
    public Guid DriverId { get; private set; }


    public static Vehicle Create(VehicleId id,Guid driverId,string vehicleMake, string vehicleModel, string vehicleYear, string vehicleColor, string vehiclePlateNumber, string vehicleType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleType);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleColor);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehiclePlateNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleModel);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleMake);

        return new Vehicle
        {
            Id =id,
            DriverId = driverId,
            VehicleMake = vehicleMake,
            VehicleModel = vehicleModel,
            VehicleYear = vehicleYear,
            VehicleColor = vehicleColor,
            VehiclePlateNumber = vehiclePlateNumber,
            VehicleType = vehicleType
        };
    }
}
