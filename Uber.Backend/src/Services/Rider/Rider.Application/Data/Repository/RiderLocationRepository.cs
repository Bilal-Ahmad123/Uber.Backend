using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using StackExchange.Redis;

namespace Rider.Application.Data.Repository;
public class RiderLocationRepository:IRiderLocationRepository
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    public RiderLocationRepository(IConnectionMultiplexer connection)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
    }

    public void GetDriverLocationUpdate()
    {
        throw new NotImplementedException();
    }

    public async void SendRiderLocationUpdate(UpdateUserLocation driverLocation)
    {
        var driverLocationMessage = JsonSerializer.Serialize(driverLocation);
        await _pubsub.PublishAsync(RedisChannel.Literal("rider_location_updates"), driverLocationMessage);
    }
}
