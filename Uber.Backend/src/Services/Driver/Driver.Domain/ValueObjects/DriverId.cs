using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Domain.ValueObjects;
public class DriverId
{
    public Guid Value { get; }

    private DriverId(Guid value) => Value = value;

    public static DriverId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("VehicleId cannot be empty");
        }
        return new DriverId(value);
    }
}
