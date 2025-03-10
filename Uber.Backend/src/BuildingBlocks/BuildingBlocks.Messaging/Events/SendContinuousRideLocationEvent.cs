using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events
{
    public record SendContinuousRideLocationEvent(Guid RideId, Guid DriverId, double Longitude, double Latitude, Guid RiderId)
}
