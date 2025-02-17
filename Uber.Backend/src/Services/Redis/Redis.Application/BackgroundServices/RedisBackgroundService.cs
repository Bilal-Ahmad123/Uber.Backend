using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Redis.Application.BackgroundServices;
public class RedisBackgroundService : BackgroundService
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    public RedisBackgroundService(IConnectionMultiplexer connection)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _pubsub.SubscribeAsync(RedisChannel.Literal("driver_location_updates"), async (channel, message) =>
        {
            if(message.HasValue)
            {
                string messageContent = message.ToString();
                UpdateDriverLocationEvent? driverUpdate = null;
                if (!string.IsNullOrEmpty(messageContent))
                {
                     driverUpdate = JsonSerializer.Deserialize<UpdateDriverLocationEvent>(messageContent);
                }
                var riderRadius = 5;
                var nearbyRiders = await _redis.GeoRadiusAsync("riders:locations", driverUpdate?.Longitude, driverUpdate!.Latitude, GeoUnit.Kilometers, riderRadius);
                if(nearbyRiders.Length > 0)
                {
                    var riderMessage = JsonSerializer.Serialize(
                        new
                        {
                            DriverId = driverUpdate?.DriverId,
                            Latitude = driverUpdate?.Latitude,
                            Longitude = driverUpdate?.Longitude
                            NearbyRiders = nearbyRiders.Select(r => r.Member).ToList()
                        }
                        );
                    await _pubsub.PublishAsync(RedisChannel.Literal("nearby_driver_updates"), riderMessage);
                }
            }

        });
    }
}
