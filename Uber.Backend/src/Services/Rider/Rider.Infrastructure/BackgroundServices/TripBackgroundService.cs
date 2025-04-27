using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Common;
using BuildingBlocks.Models.Ride;
using BuildingBlocks.PubSub.Subscribers;
using Microsoft.Extensions.Hosting;
using Rider.Application.Data.Services;
using StackExchange.Redis;

namespace Rider.Infrastructure.BackgroundServices;
public class TripBackgroundService:BackgroundService
{
    private readonly IDatabase _redis;
    private readonly ISubscriber _pubsub;
    private readonly ISignalRService _signalRService;
    public TripBackgroundService(IConnectionMultiplexer connection, ISignalRService signalRService)
    {
        _redis = connection.GetDatabase();
        _pubsub = connection.GetSubscriber();
        _signalRService = signalRService;

    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _pubsub.SubscribeAsync(RedisChannel.Literal(PubSubSusbcribers.TRIP_UPDATES), (channel, message) =>
        {
            if (message.HasValue)
            {
                string messageContent = message.ToString();
                ContinuousTripUpdates? driverUpdate = null;
                if (!string.IsNullOrEmpty(messageContent))
                {
                    driverUpdate = Helper.Deserializer<ContinuousTripUpdates>(messageContent);
                }
                _signalRService.SendTripLocationToRiders(driverUpdate!);
            }
        });
        return Task.CompletedTask;
    }
}
