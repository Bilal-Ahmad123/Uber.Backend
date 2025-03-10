using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using BuildingBlocks.Events.Driver;
using BuildingBlocks.Messaging.Events;
using RideMatching.Application.Rides.Services;
using StackExchange.Redis;


namespace RideMatching.Infrastructure.Services
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _redisDb;
        public RedisService(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }

        public async Task<IList<Guid>> FindNearbyDrivers(Guid riderId)
        {
            var riderLocation = await _redisDb.GeoPositionAsync("riders:locations", riderId.ToString());
            int riderRadius = 5;
                var nearbyDrivers = await _redisDb.GeoSearchAsync(
                    "drivers:locations",              
                    riderLocation.Value.Longitude,      
                    riderLocation.Value.Latitude,
                    new GeoSearchCircle(riderRadius,GeoUnit.Kilometers)      
                );
            return nearbyDrivers.Select(r => Guid.Parse(r.Member.ToString())).ToList();
        }

        public async void LockRideRequest(Guid rideId,Guid driverId)
        {
            var lockKey = $"ride_lock:{rideId}";
            await _redisDb.LockTakeAsync(lockKey, driverId.ToString(),TimeSpan.FromSeconds(10));
        }

        public void StoreRideRequest(RequestRideEvent rideRequest)
        {
            _redisDb.StringSet(rideRequest.RideId.ToString(), JsonSerializer.Serialize(rideRequest),TimeSpan.FromSeconds(60));
        }

        public Guid GetRiderId(Guid rideId)
        {
            var rideRequest = _redisDb.StringGet(rideId.ToString());

            if (rideRequest.IsNullOrEmpty)
            {
                throw new InvalidOperationException($"No ride request found for rideId: {rideId}");
            }

            var request = JsonSerializer.Deserialize<RequestRideEvent>(rideRequest.ToString());

            if (request == null)
            {
                throw new InvalidOperationException("Failed to deserialize ride request.");
            }

            return request.RiderId;
        }
    }
}
