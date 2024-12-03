﻿namespace Uber.Backend.EFCore.Caching.Redis.Configuration;

internal sealed record RedisConnection
{
    [NotNull]
    public string? ConnectionString { get; init; }

    public bool HealthCheckEnabled { get; init; }
}
