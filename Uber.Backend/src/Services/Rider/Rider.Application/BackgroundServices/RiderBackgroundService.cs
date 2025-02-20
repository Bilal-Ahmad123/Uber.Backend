using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace Rider.Application.BackgroundServices;
public class RiderBackgroundService : BackgroundService
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    public RiderBackgroundService(IConnectionMultiplexer connection)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();

    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _pubsub.SubscribeAsync(RedisChannel.Literal("nearby_driver_updates"), (channel, message) =>
        {
            if (message.HasValue)
            {
                string messageContent = message.ToString();
                UpdateUserLocation? driverUpdate = null;
                if (!string.IsNullOrEmpty(messageContent))
                {
                    driverUpdate = JsonSerializer.Deserialize<UpdateUserLocation>(messageContent);
                }
            }
        });
        return Task.CompletedTask;
    }
}
