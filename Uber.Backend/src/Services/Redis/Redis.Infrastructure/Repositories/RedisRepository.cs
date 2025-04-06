using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Common;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Driver;
using BuildingBlocks.Models.Rider;
using Redis.Application.Repositories;
using StackExchange.Redis;

namespace Redis.Infrastructure.Repositories;
public class RedisRepository : IRedisRepository
{
    private readonly IDatabase _redis;
    public RedisRepository(IConnectionMultiplexer connection)
    {
        _redis = connection.GetDatabase();
    }
    public string GetNearbyDrivers(UpdateUserLocation rideRequest, int radius = 5)
    {

            var nearbyDrivers = _redis.GeoRadius(
                               "drivers:locations",
                                rideRequest!.Longitude,
                                rideRequest.Latitude,
                                radius,
                               GeoUnit.Kilometers
            );

            if(nearbyDrivers.Length > 0)
            {
                var drivers = JsonSerializer.Serialize(
                    new
                    {
                        UserId = rideRequest.UserId,
                        Latitude = rideRequest.Latitude,
                        Longitude = rideRequest.Longitude,
                        Drivers = nearbyDrivers.Select(r => r.Member.ToString()).ToList(),
                        DriversWithTimeAway = nearbyDrivers.Select(r => new
                        {
                            Id = r.Member.ToString(),
                            TimeAway = Helper.CalculateTimeAway(r.Distance ?? 0.0)
                        })
                    }
                );
                return drivers;

            }
        return string.Empty;
    }

    public string GetNearbyRiders(UpdateDriverLocation driverLocation, int radius = 5)
    {

            var nearbyRiders = _redis.GeoRadius(
                               "riders:locations",
                                driverLocation!.Longitude,
                                driverLocation.Latitude,
                                radius,
                               GeoUnit.Kilometers
            );

            if (nearbyRiders.Length > 0)
            {
                var riders = JsonSerializer.Serialize(
                    new
                    {
                        UserId = driverLocation?.UserId,
                        Latitude = driverLocation?.Latitude,
                        Longitude = driverLocation?.Longitude,
                        VehicleType = driverLocation?.VehicleType,
                        Riders = nearbyRiders.Select(r => r.Member.ToString()).ToList()
                    }
                );
                return riders;

            }
        return string.Empty;
    }

    public Task DeleteDriverLocation(Guid driverId)
    {
        throw new NotImplementedException();
    }

    public Task GetDriverLocation(Guid driverId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateDriverLocation(UpdateUserLocation driverLocation)
    {
        await _redis.GeoAddAsync("drivers:locations", driverLocation.Longitude, driverLocation.Latitude, driverLocation.UserId.ToString());
    }

    public Task DeleteRiderLocation(Guid riderId)
    {
        throw new NotImplementedException();
    }

    public Task GetRiderLocation(Guid driverId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRiderLocation(UpdateUserLocation riderLocation)
    {
        await _redis.GeoAddAsync("riders:locations", riderLocation.Longitude, riderLocation.Latitude, riderLocation.UserId.ToString());
    }

}
