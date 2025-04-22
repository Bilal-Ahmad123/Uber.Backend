using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Models.Driver
{
    public record NearbyDriverResponse(IList<Guid> DriverIds, IList<DriversWithTime> DriversWithTimeAway);
    public record DriversWithTime(Guid Id, int TimeAway);
}
