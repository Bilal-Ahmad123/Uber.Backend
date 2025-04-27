using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Domain.Models.Driver;
public record AcceptRideRequest(
    Guid RideId,
    Guid DriverId,
    double Latitude,
    double Longitude,
    Guid rideId
);
