using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Rider.Application.Data.Repository;
public class RiderLocationRepository:IRiderLocationRepository
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    private readonly ILogger _logger;
    public RiderLocationRepository(IConnectionMultiplexer connection,ILogger<RiderLocationRepository> logger)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
        _logger = logger;
    }

    public void GetDriverLocationUpdate()
    {
        throw new NotImplementedException();
    }

    public async void SendRiderLocationUpdate(UpdateUserLocation driverLocation)
    {
        try
        {
            var driverLocationMessage = JsonSerializer.Serialize(driverLocation);
            await _pubsub.PublishAsync(RedisChannel.Literal("rider_location_updates"), driverLocationMessage);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.ToString());
        }
    }
}
