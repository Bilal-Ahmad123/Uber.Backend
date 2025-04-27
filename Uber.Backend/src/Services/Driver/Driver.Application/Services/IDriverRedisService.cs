using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Ride;

namespace Driver.Application.Services
{
    public interface IDriverRedisService
    {
        void SendDriverLocationUpdate(UpdateUserLocation driverLocation);
        void GetDriverLocationUpdate();
        void SendTripLocationUpdates(ContinuousTripUpdates trip);
    }
}
