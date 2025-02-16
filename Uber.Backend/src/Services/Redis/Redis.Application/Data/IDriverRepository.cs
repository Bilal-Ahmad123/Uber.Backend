using BuildingBlocks.Events;

namespace Redis.Application.Data;
public interface IDriverRepository
{
    public Task UpdateDriverLocation(UpdateDriverLocationEvent driverLocation);
    public Task GetDriverLocation(Guid driverId);
    public Task DeleteDriverLocation(Guid driverId);
}
