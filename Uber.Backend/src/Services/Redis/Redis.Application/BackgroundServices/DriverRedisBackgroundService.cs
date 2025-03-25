using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Common;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Driver;
using Mapster;
using Microsoft.Extensions.Hosting;
using Redis.Application.Repositories;
using StackExchange.Redis;

namespace Redis.Application.BackgroundServices;
public class DriverRedisBackgroundService : BackgroundService
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    private readonly IRedisRepository _redisRepository;
    public DriverRedisBackgroundService(IConnectionMultiplexer connection,IRedisRepository redisRepository)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
        _redisRepository = redisRepository;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _pubsub.SubscribeAsync(RedisChannel.Literal("driver_location_updates"), async (channel, message) =>
        {
            if (message.HasValue)
            {
                string messageContent = message.ToString();
                UpdateDriverLocation? driverUpdate = null;
                if (!string.IsNullOrEmpty(messageContent))
                {
                    driverUpdate = Helper.Deserializer<UpdateDriverLocation>(messageContent);
                    await _redisRepository.UpdateDriverLocation(driverUpdate.Adapt<UpdateUserLocation>());
                    if(driverUpdate != null)
                    {
                        var riderMessage = _redisRepository.GetNearbyRiders(driverUpdate);
                        await _pubsub.PublishAsync(RedisChannel.Literal("nearby_driver_updates"), riderMessage);
                    }
                }
            }

        });
    }
}
