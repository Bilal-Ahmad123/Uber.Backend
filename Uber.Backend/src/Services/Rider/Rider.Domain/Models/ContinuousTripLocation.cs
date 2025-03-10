using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rider.Domain.Models
{
   public record ContinuousTripLocation(Guid RideId, Guid DriverId, double Longitude, double Latitude, Guid RiderId);
}
