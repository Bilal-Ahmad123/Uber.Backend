using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Ride;
using BuildingBlocks.PubSub.Subscribers;
using Driver.Application.Services;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Driver.Infrastructure.Services
{
    class DriverRedisService: IDriverRedisService
    {
        private readonly IDatabase _redis;
        private readonly ISubscriber _pubsub;
        private readonly ILogger _logger;
        public DriverRedisService(IConnectionMultiplexer connection, ILogger<DriverRedisService> logger)
        {
            _redis = connection.GetDatabase();
            _pubsub = connection.GetSubscriber();
            _logger = logger;
        }

        public void GetDriverLocationUpdate()
        {
            throw new NotImplementedException();
        }

        public async void SendDriverLocationUpdate(UpdateUserLocation driverLocation)
        {
            try
            {
                var driverLocationMessage = JsonSerializer.Serialize(driverLocation);
                await _pubsub.PublishAsync(RedisChannel.Literal("driver_location_updates"), driverLocationMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        public async void SendTripLocationUpdates(ContinuousTripUpdates trip)
        {
            try
            {
                var tripMessage = JsonSerializer.Serialize(trip);
                await _pubsub.PublishAsync(RedisChannel.Literal(PubSubSusbcribers.TRIP_UPDATES), tripMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
