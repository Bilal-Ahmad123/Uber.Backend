using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events.Driver;
using BuildingBlocks.Messaging.Events;

namespace RideMatching.Application.Rides.Services
{
    public interface IRedisService
    {
        void StoreRideRequest(RequestRideEvent rideRequest);
        Task<IList<Guid>> FindNearbyDrivers(Guid riderId);
    }
}
