using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Backend.Redis.Configuration;
public class RedisConnection
{
    [NotNull]
    public string? ConnectionString { get; init; }

    public bool HealthCheckEnabled { get; init; }
}
