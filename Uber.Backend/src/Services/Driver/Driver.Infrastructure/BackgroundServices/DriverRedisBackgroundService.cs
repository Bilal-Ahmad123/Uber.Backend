using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Models.Rider;
using Driver.Application.Services;
using Driver.Domain.Models.RiderLocation;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace Driver.Infrastructure.BackgroundServices;
internal class DriverRedisBackgroundService : BackgroundService
{
    private readonly IDatabase _redis;
    private readonly ISignalRService _signalRService;
    private readonly ISubscriber _pubsub;
    public DriverRedisBackgroundService(IConnectionMultiplexer connection,ISignalRService signalRService)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
        _signalRService = signalRService;

    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
       await _pubsub.SubscribeAsync(RedisChannel.Literal("driver_ride_request_recieved"), (channel, message) =>
        {
            if (message.HasValue)
            {
                string messageContent = message.ToString();
                RiderRequestedLocation? rideRequest = null;
                if (!messageContent.IsNullOrEmpty())
                {
                    rideRequest = JsonSerializer.Deserialize<RiderRequestedLocation>(messageContent);
                }
                _signalRService.SendRideRequestToDriver(rideRequest!);

            }
        });
    }
}
