using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rider.Domain.Models;
public record DriverPositionWithRiders(Guid UserId,double Longitude, double Latitude,IList<Guid> Riders, string VehicleType);
