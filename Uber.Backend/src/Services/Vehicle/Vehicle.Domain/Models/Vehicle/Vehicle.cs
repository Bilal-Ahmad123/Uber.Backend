

using Vehicle.Domain.ValueObjects;

namespace Vehicle.Domain.Models.Vehicle;
public class Vehicle
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string VehicleMake { get; private set; } = default!;
    public string VehicleModel { get; private set; } = default!;
    public string VehicleYear { get; private set; } = default!;
    public string VehicleColor { get; private set; } = default!;
    public string VehiclePlateNumber { get; private set; } = default!;
    public string VehicleType { get; private set; } = default!;
    public Guid DriverId { get; private set; }
    public AllVehicleModel AllVehicleModel { get; set; } = default!;

    public VehicleId AllVehicleModelId { get; set; } = default!;


    public static Vehicle Create(Guid driverId,string vehicleMake, string vehicleModel, string vehicleYear, string vehicleColor, string vehiclePlateNumber, string vehicleType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleType);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleColor);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehiclePlateNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleModel);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleMake);

        return new Vehicle
        {
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
