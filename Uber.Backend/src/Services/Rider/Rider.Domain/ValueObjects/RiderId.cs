using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rider.Domain.ValueObjects;
public class RiderId
{
    public Guid Value { get; }

    private RiderId(Guid value) => Value = value;

    public static RiderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new Exception("DriverId cannot be empty");
        }
        return new RiderId(value);
    }
}
