﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events
{
    public record AcceptRideRequestEvent(Guid DriverId, Guid RideId, double Latitude, double Longitude, Guid RiderId);
}
