
namespace Driver.Domain.Models.Vehicle;
public class Vehicle:Entity<>
{
    public string VehicleMake { get; private set; } = default!;
    public string VehicleModel { get; private set; } = default!;
    public DateTime VehicleYear { get; private set; } = default!;
    public string VehicleColor { get; private set; } = default!;
    public string VehiclePlateNumber { get; private set; } = default!;
    public string VehicleType { get; private set; } = default!;

}
