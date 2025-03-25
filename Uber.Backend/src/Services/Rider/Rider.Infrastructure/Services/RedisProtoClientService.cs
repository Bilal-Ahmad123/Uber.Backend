using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Redis;
using Rider.Application.Services;

namespace Rider.Infrastructure.Services;
public class RedisProtoClientService : IRedisProtoClientService
{
    private readonly RedisService.RedisServiceClient _redisClient;

    public RedisProtoClientService(RedisService.RedisServiceClient redisClient)
    {
        _redisClient = redisClient;
    }

    public List<Guid> GetNearbyDrivers(UpdateUserLocation riderLocation)
    {
        var response = _redisClient.GetNearbyDrivers(new NearbyDriversRequest
        {
            Latitude = riderLocation.Latitude,
            Longitude = riderLocation.Longitude,
            UserId = riderLocation.UserId.ToString()
        });
        return response.DriverIds.Select(d => new Guid(d)).ToList();
    }
}
