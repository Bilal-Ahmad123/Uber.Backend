
using System.Text.Json;
using BuildingBlocks.Events;
using Microsoft.Extensions.Logging;
using Rider.Application.Data.Services;
using StackExchange.Redis;

namespace Rider.Infrastructure.Services;
public class RiderLocationService:IRiderLocationService
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    private readonly ILogger _logger;
    public RiderLocationService(IConnectionMultiplexer connection,ILogger<RiderLocationService> logger)
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
