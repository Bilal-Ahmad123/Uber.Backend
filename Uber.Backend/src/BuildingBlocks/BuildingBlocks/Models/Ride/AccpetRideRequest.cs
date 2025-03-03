using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Models.Ride;
public record AcceptRideRequest(Guid DriverId, Guid RiderId);
