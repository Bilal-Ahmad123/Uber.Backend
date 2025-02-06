using Authentication.Domain.Exceptions;

namespace Authentication.Domain.ValueObjects;
public class DriverId
{
    public Guid Value { get; private set; }
    private DriverId(Guid value) => Value = value;
    public static DriverId of(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id);
        if (id == Guid.Empty)
        {
            throw new DomainException("DriverId cannot be empty");
        }
        return new DriverId(id);
    }
}
