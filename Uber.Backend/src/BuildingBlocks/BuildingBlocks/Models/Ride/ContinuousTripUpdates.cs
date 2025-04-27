using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Models.Ride
{
    public record ContinuousTripUpdates(
        Guid RideId,
        Guid DriverId,
        Guid RiderId,
        double Latitude,
        double Longitude,
        string VehicleType
    );
}
