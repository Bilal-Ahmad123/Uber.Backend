using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Common;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Rider;
using Microsoft.Extensions.Hosting;
using Redis.Application.Repositories;
using StackExchange.Redis;

namespace Redis.Application.BackgroundServices
{
    class RideRequestBackgroundService : BackgroundService
    {
        private readonly IDatabase _redis;
        private readonly ISubscriber _pubsub;
        private readonly IRedisRepository _redisRepository;
        public RideRequestBackgroundService(IConnectionMultiplexer connection, IRedisRepository redisRepository)
        {
            _redis = connection.GetDatabase();
            _pubsub = connection.GetSubscriber();
            _redisRepository = redisRepository;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _pubsub.SubscribeAsync(RedisChannel.Literal("rider_ride_requested"), async (channel, message) =>
            {
                if (message.HasValue)
                {
                    string messageContent = message.ToString();
                    UpdateUserLocation? rideRequest = null;
                    if (!string.IsNullOrEmpty(messageContent))
                    {
                        rideRequest = Helper.Deserializer<UpdateUserLocation>(messageContent);
                        var driverMessage = _redisRepository.GetNearbyDrivers(rideRequest);
                        if(driverMessage != null)
                        {
                            await _pubsub.PublishAsync(RedisChannel.Literal("driver_ride_request_recieved"), driverMessage);
                        }
                    }                  
                }
            });
        }
    }
}
