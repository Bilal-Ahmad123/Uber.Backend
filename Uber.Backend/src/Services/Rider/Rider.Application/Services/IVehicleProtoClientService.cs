using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rider.Domain.Models.Vehicle;

namespace Rider.Application.Services;
public interface IVehicleProtoClientService
{
    Task<List<NearbyVehicleDetails>> NearbyVehicleDetails(IList<Guid> driverIds);
}
