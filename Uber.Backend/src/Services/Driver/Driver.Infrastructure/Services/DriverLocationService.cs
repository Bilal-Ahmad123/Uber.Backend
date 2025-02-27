using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Driver.Application.Services;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Driver.Infrastructure.Services
{
    class DriverLocationService: IDriverLocationService
    {
        private readonly IDatabase _redis;
        private readonly ISubscriber _pubsub;
        private readonly ILogger _logger;
        public DriverLocationService(IConnectionMultiplexer connection, ILogger<DriverLocationService> logger)
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
    }
}
