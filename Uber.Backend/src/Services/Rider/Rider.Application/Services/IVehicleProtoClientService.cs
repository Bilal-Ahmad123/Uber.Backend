
using Rider.Domain.Models.Vehicle;

namespace Rider.Application.Services;
public interface IVehicleProtoClientService
{
   List<NearbyVehicleDetails> NearbyVehicleDetails(IList<Guid> driverIds);
}
