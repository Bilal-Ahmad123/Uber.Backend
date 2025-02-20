using BuildingBlocks.Events;

namespace Redis.Application.Data.DriverRepository;
public interface IDriverRepository
{
    public Task UpdateDriverLocation(UpdateUserLocation driverLocation);
    public Task GetDriverLocation(Guid driverId);
    public Task DeleteDriverLocation(Guid driverId);
}
