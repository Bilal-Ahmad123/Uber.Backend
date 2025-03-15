using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rider.Domain.Abstractions;
using Rider.Domain.ValueObjects;

namespace Rider.Domain.Models.Rider;
public class Rider:Entity<RiderId>
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string ContactNumber { get; private set; } = default!;
    public string Country { get; private set; } = default!;

    public static Rider Create(RiderId driverId, string firstName, string lastName, string contactNumber, string country)
    {
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(lastName);
        ArgumentNullException.ThrowIfNull(contactNumber);
        ArgumentNullException.ThrowIfNull(country);
        ArgumentNullException.ThrowIfNull(driverId);

        return new Rider
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
