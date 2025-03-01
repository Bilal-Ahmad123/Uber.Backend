using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Driver;
using Microsoft.Extensions.Hosting;
using Redis.Application.Data.DriverRepository;
using StackExchange.Redis;

namespace Redis.Application.BackgroundServices;
public class DriverRedisBackgroundService : BackgroundService
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    private readonly IDriverRepository _driverRepository;
    public DriverRedisBackgroundService(IConnectionMultiplexer connection,IDriverRepository driverRepository)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
        _driverRepository = driverRepository;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _pubsub.SubscribeAsync(RedisChannel.Literal("driver_location_updates"), async (channel, message) =>
        {
            if(message.HasValue)
            {
                string messageContent = message.ToString();
                UpdateDriverLocation? driverUpdate = null;
                if (!string.IsNullOrEmpty(messageContent))
                {
                     driverUpdate = JsonSerializer.Deserialize<UpdateDriverLocation>(messageContent);
                    await _driverRepository.UpdateDriverLocation(driverUpdate!);
                }
                var riderRadius = 5;
                var nearbyRiders =  _redis.GeoRadius(
                                "riders:locations",
                                 driverUpdate!.Longitude, 
                                 driverUpdate.Latitude,   
                                 riderRadius,             
                                GeoUnit.Kilometers      
                           );
                if (nearbyRiders.Length > 0)
                {
                    var riderMessage = JsonSerializer.Serialize(
                        new
                        {
                            UserId = driverUpdate?.UserId,
                            Latitude = driverUpdate?.Latitude,
                            Longitude = driverUpdate?.Longitude,
                            VehicleType = driverUpdate?.VehicleType,
                            Riders = nearbyRiders.Select(r => r.Member.ToString()).ToList()
                        }
                        );
                    await _pubsub.PublishAsync(RedisChannel.Literal("nearby_driver_updates"), riderMessage);
                }
            }

        });
    }
}
