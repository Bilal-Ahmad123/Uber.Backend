using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Models.Rider;
public record RideRequest(Guid RiderId, PickUpLocation PickUpLocation,DropOffLocation DropOffLocation);
