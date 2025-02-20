using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Microsoft.Extensions.Hosting;
using Redis.Application.Data.RiderRepository;
using StackExchange.Redis;

namespace Redis.Application.BackgroundServices;
internal class RiderRedisBackgroundService : BackgroundService
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    private readonly IRiderRedisRepository _riderRedisRepository;
    public RiderRedisBackgroundService(IConnectionMultiplexer connection,IRiderRedisRepository riderRedisRepository)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
        _riderRedisRepository = riderRedisRepository;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _pubsub.SubscribeAsync(RedisChannel.Literal("rider_location_updates"), async (channel, message) =>
        {
            if (message.HasValue)
            {
                string messageContent = message.ToString();
                UpdateUserLocation? riderUpdate = null;
                if (!string.IsNullOrEmpty(messageContent))
                {
                    riderUpdate = JsonSerializer.Deserialize<UpdateUserLocation>(messageContent);
                    await _riderRedisRepository.UpdateRiderLocation(riderUpdate!);
                }
            }
        });

    }
}
