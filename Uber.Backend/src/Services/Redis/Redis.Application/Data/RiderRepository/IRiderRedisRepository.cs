using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;

namespace Redis.Application.Data.RiderRepository;
public interface IRiderRedisRepository
{
    public Task UpdateRiderLocation(UpdateUserLocation riderLocation);
    public Task GetDriverLocation(Guid driverId);
    public Task DeleteDriverLocation(Guid driverId);
}
