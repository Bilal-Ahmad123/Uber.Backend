using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redis;
using Rider.Application.Services;

namespace Rider.Infrastructure.Services;
public class RedisProtoClientService : IRedisProtoClientService
{
    private readonly RedisService.RedisServiceClient _client;

    public List<Guid> GetNearbyDrivers()
    {
        _client.GetNearbyDriversAsync()
    }
}
