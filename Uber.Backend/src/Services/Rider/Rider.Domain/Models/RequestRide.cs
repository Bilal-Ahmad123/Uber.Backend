using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rider.Domain.Models
{
    public record RequestRide(Guid RiderId, double PickupLongitude, double PickupLatitude,double DropoffLatitude,double DropoffLongitude);
}
