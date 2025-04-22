using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Models.Driver;
using BuildingBlocks.Models.Rider;

namespace RideMatching.Application.Rides.Services;
public interface IRedisProtoClientService
{
    NearbyDriverResponse GetNearbyDrivers(UpdateUserLocation riderLocation);
    void StoreRideRequest(RequestRideEvent requestRide);
}
