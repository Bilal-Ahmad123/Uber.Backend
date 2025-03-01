using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Driver;
using StackExchange.Redis;

namespace Driver.Application.Data.Repository;
public class DriverUpdateLocationRepository : IDriverUpdateLocationRepository
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    public DriverUpdateLocationRepository(IConnectionMultiplexer connection)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
    }
    public void GetDriverLocationUpdate()
    {
        throw new NotImplementedException();
    }

    public async void SendDriverLocationUpdate(UpdateDriverLocation driverLocation)
    {
        var driverLocationMessage = JsonSerializer.Serialize(driverLocation);
        await _pubsub.PublishAsync(RedisChannel.Literal("driver_location_updates"), driverLocationMessage);
    }
}
