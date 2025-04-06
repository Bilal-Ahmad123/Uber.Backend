using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Redis;
using Rider.Application.Services;
using Rider.Domain.Models.Rider;

namespace Rider.Infrastructure.Services;
public class RedisProtoClientService : IRedisProtoClientService
{
    private readonly RedisService.RedisServiceClient _redisClient;

    public RedisProtoClientService(RedisService.RedisServiceClient redisClient)
    {
        _redisClient = redisClient;
    }

    public NearbyDriverResponse GetNearbyDrivers(UpdateUserLocation riderLocation)
    {
        var response = _redisClient.GetNearbyDrivers(new NearbyDriversRequest
        {
            Latitude = riderLocation.Latitude,
            Longitude = riderLocation.Longitude,
            UserId = riderLocation.UserId.ToString()
        });
        var driversWithTime = response.DriversWithTimeAway.Select(r =>
        {
            return new DriversWithTime(new Guid(r.DriverId), Int32.Parse(r.TimeAway));
        }).ToList();

        var driverIds = response.DriverIds.Select(d => new Guid(d)).ToList();
        return new NearbyDriverResponse(driverIds, driversWithTime);
    }
}
