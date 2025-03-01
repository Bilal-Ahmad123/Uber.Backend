using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Models.Driver;
public record UpdateDriverLocation(Guid UserId, double Latitude, double Longitude, string VehicleType);

