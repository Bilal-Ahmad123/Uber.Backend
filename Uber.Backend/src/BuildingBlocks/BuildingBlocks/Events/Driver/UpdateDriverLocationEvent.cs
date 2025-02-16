using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events;
public record UpdateDriverLocationEvent(Guid DriverId, double Latitude, double Longitude);
