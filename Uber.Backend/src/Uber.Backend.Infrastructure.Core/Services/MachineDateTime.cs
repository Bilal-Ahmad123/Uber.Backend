namespace Uber.Backend.Infrastructure.Core.Services;

public sealed class MachineDateTime : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
