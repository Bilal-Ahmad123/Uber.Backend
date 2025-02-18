using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events;
public record UpdateDriverLocation(Guid DriverId, double Latitude, double Longitude);
