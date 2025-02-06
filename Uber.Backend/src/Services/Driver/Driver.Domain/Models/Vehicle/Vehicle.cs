
using Driver.Domain.ValueObjects;

namespace Driver.Domain.Models.Vehicle;
public class Vehicle:Entity<VehicleId>
{
    public string VehicleMake { get; private set; } = default!;
    public string VehicleModel { get; private set; } = default!;
    public DateTime VehicleYear { get; private set; } = default!;
    public string VehicleColor { get; private set; } = default!;
    public string VehiclePlateNumber { get; private set; } = default!;
    public string VehicleType { get; private set; } = default!;

    public static Vehicle Create(VehicleId id,string vehicleMake, string vehicleModel, DateTime vehicleYear, string vehicleColor, string vehiclePlateNumber, string vehicleType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleType);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleColor);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehiclePlateNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleModel);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleMake);

        return new Vehicle
        {
            Id =id,
            VehicleMake = vehicleMake,
            VehicleModel = vehicleModel,
            VehicleYear = vehicleYear,
            VehicleColor = vehicleColor,
            VehiclePlateNumber = vehiclePlateNumber,
            VehicleType = vehicleType
        };
    }
}
