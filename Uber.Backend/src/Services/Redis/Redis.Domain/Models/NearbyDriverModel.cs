using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Domain.Models
{
    public record NearbyDriverModel(Guid UserId, double Latitude, double Longitude, IList<Guid> Drivers);
}
