using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Models.Rider;

namespace Driver.Domain.Models.RiderLocation;
public record RiderRequestedLocation(PickUpLocation PickUpLocation, DropOffLocation DropOffLocation, Guid RiderId, IList<Guid> NearbyDrivers, Guid RideId);
