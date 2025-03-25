using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Driver;
using BuildingBlocks.Models.Rider;
using StackExchange.Redis;

namespace Redis.Application.Repositories;
public interface IRedisRepository
{
    string GetNearbyDrivers(UpdateUserLocation message, int radius = 5);
    string GetNearbyRiders(UpdateDriverLocation message, int radius = 5);
    public Task UpdateDriverLocation(UpdateUserLocation driverLocation);
    public Task GetDriverLocation(Guid driverId);
    public Task DeleteDriverLocation(Guid driverId);
    public Task UpdateRiderLocation(UpdateUserLocation riderLocation);
    public Task GetRiderLocation(Guid riderId);
    public Task DeleteRiderLocation(Guid riderId);
}
