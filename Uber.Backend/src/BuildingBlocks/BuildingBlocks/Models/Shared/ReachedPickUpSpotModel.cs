using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Models.Shared;
public record ReachedPickUpSpotModel(
    Guid RiderId,
    Guid DriverId,
    Guid RideId,
    string Reached
);
