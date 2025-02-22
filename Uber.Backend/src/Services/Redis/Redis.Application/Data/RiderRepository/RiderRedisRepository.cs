using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using StackExchange.Redis;

namespace Redis.Application.Data.RiderRepository;
public class RiderRedisRepository : IRiderRedisRepository
{
    private readonly IDatabase _redisDb;
    public RiderRedisRepository(IConnectionMultiplexer redis)
    {
        _redisDb = redis.GetDatabase();
    }
    public Task DeleteDriverLocation(Guid driverId)
    {
        throw new NotImplementedException();
    }

    public Task GetDriverLocation(Guid driverId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRiderLocation(UpdateUserLocation riderLocation)
    {
        await _redisDb.GeoAddAsync("riders:locations", riderLocation.Longitude, riderLocation.Latitude, riderLocation.UserId.ToString());
    }
}
