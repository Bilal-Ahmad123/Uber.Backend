using Rider.Application.Services;
using Rider.Domain.Models.Rider;
using Rider.Domain.Models.Vehicle;
using Vehicle;

namespace Rider.Infrastructure.Services;
public class VehicleProtoService : IVehicleProtoClientService
{
    private readonly VehicleService.VehicleServiceClient _vehicleServiceClient;

    public VehicleProtoService(VehicleService.VehicleServiceClient vehicleServiceClient)
    {
        _vehicleServiceClient = vehicleServiceClient;
    }
    public List<NearbyVehicleDetails> NearbyVehicleDetails(IList<Guid> driverIds, IList<DriversWithTime> driversWithTimeAway)
    {
        var result = _vehicleServiceClient.GetVehicleDetails(new VehicleRequest
        {
            DriverId = { driverIds.Select(d => d.ToString()) }
        });
        var vehicles =  result.VehicleResponse.Select(v => new NearbyVehicleDetails
        (
            v.VehicleType,
            v.ImageUrl,
            v.MaxSeats,
            (decimal)v.Fare,
            v.VehicleDescription,
            GetDriverAwayTime(driversWithTimeAway,new Guid(v.DriverId))
        )).ToList();

        return vehicles;
    }

    private int GetDriverAwayTime(IList<DriversWithTime> driversWithTimeAway,Guid driverId)
    {
       var driver =  driversWithTimeAway.FirstOrDefault(x => x.Id.Equals(driverId));
       return driver!.TimeAway;
    }


}
