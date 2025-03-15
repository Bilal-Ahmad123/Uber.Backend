using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Domain.ValueObjects;

namespace Driver.Domain.Models.Driver;
public class Driver:Entity<DriverId>
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string ContactNumber { get; private set; } = default!;
    public string Country { get; private set; } = default!;

    public static Driver Create(DriverId driverId , string firstName, string lastName, string contactNumber, string country)
    {
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(lastName);
        ArgumentNullException.ThrowIfNull(contactNumber);
        ArgumentNullException.ThrowIfNull(country);
        ArgumentNullException.ThrowIfNull(driverId);

        return new Driver
        {
            Id = driverId,
            FirstName = firstName,
            LastName = lastName,
            ContactNumber = contactNumber,
            Country = country,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow
        };
    }
}
