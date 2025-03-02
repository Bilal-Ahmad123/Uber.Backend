using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Models.Rider;

namespace BuildingBlocks.Messaging.Events;
public record DriverRideRequestEvent(Guid RideId, Guid RiderId, PickUpLocation? PickUpLocation, DropOffLocation? DropOffLocation, IList<Guid> NearbyDrivers);
