using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Models.Rider;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Redis.Application.BackgroundServices
{
    class RideRequestBackgroundService : BackgroundService
    {
        private readonly IDatabase _redis;
        private readonly ISubscriber _pubsub;
        public RideRequestBackgroundService(IConnectionMultiplexer connection)
        {
            _redis = connection.GetDatabase();
            _pubsub = connection.GetSubscriber();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _pubsub.SubscribeAsync(RedisChannel.Literal("rider_ride_requested"), async (channel, message) =>
            {
                if (message.HasValue)
                {
                    string messageContent = message.ToString();
                    RideRequest? rideRequest = null;
                    if (!string.IsNullOrEmpty(messageContent))
                    {
                        rideRequest = JsonSerializer.Deserialize<RideRequest>(messageContent);
                    }
                    var riderRadius = 5;
                    var nearbyDrivers = _redis.GeoRadius(
                                "drivers:locations",
                                 rideRequest!.PickUpLocation.Longitude,
                                 rideRequest.PickUpLocation.Latitude,
                                 riderRadius,
                                GeoUnit.Kilometers
                          );
                    if(nearbyDrivers.Length > 0)
                    {
                        var driverMessage = JsonSerializer.Serialize(
                            new
                            {
                                RiderId = rideRequest.RiderId,
                                PickUpLocation = rideRequest.PickUpLocation,
                                DropOffLocation = rideRequest.DropOffLocation,
                                Drivers = nearbyDrivers.Select(r => r.Member.ToString()).ToList()
                            }
                            );
                        await _pubsub.PublishAsync(RedisChannel.Literal("driver_ride_request_recieved"), driverMessage);
                    }

                }
            });
        }
    }
}
