using BuildingBlocks.Events;
using StackExchange.Redis;

namespace Redis.Application.Data.DriverRepository;
public class DriverRepository : IDriverRepository
{
    private readonly IDatabase _redisDb;
    public DriverRepository(IConnectionMultiplexer redis)
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

    public async Task UpdateDriverLocation(UpdateUserLocation driverLocation)
    {
        await _redisDb.GeoAddAsync("drivers:locations", driverLocation.Latitude, driverLocation.Longitude, driverLocation.UserId.ToString());
    }
}
