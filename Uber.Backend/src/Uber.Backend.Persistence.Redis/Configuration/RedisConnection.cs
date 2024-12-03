namespace Uber.Backend.Persistence.Redis.Configuration;

internal sealed record RedisConnection
{
    [NotNull]
    public string? ConnectionString { get; init; }

    public bool HealthCheckEnabled { get; init; }
}
