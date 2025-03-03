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
            _redisDb.StringSet(rideRequest.RideId.ToString(), JsonSerializer.Serialize(rideRequest),TimeSpan.FromSeconds(6000));
        }

    }
}
