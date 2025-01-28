namespace Authentication.Domain.Models;
public class Driver : Entity<UserId>
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string ContactNumber { get; private set; } = default!;
    public string Country { get; private set; } = default!;
    public string VehicleType { get; private set; } = default!;
    public string VehicleModel { get; private set; } = default!;
    public string VehiclePlateNumber { get; private set; } = default!;
    public string VehicleColor { get; private set; } = default!;
    public string VehicleYear { get; private set; } = default!;
    public string VehicleMake { get; private set; } = default!;

    public static Driver Create(UserId id,string firstName, string lastName,
        string email, string contactNo, string country,
        string vehicleType,string vehicleModel,
        string vehiclePlateNumber, string vehicleColor,
        string vehicleYear, string vehicleMake)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(contactNo);
        ArgumentException.ThrowIfNullOrWhiteSpace(country);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleType);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleModel);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehiclePlateNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleColor);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleYear);
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleMake);

        return new Driver
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            ContactNumber = contactNo,
            Country = country,
            VehicleType = vehicleType,
            VehicleModel = vehicleModel,
            VehiclePlateNumber = vehiclePlateNumber,
            VehicleColor = vehicleColor,
            VehicleYear = vehicleYear,
            VehicleMake = vehicleMake
        };
    }
}
