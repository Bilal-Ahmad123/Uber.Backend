using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Rider.Application.Data.Services;
using Rider.Domain.Models;
using StackExchange.Redis;

namespace Rider.Infrastructure.BackgroundServices;
public class RiderBackgroundService : BackgroundService
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    private readonly ISignalRService _signalRService;
    public RiderBackgroundService(IConnectionMultiplexer connection, ISignalRService signalRService)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
        _signalRService = signalRService;

    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _pubsub.SubscribeAsync(RedisChannel.Literal("nearby_driver_updates"), (channel, message) =>
        {
            if (message.HasValue)
            {
                string messageContent = message.ToString();
                DriverPositionWithRiders? driverUpdate = null;
                if (!string.IsNullOrEmpty(messageContent))
                {
                    driverUpdate = JsonSerializer.Deserialize<DriverPositionWithRiders>(messageContent);
                }
                _signalRService.SendDriverLocationToRiders(driverUpdate);
            }
        });
        return Task.CompletedTask;
    }
}
