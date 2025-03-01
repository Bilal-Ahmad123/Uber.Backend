using BuildingBlocks.Events;
using BuildingBlocks.Models.Driver;

namespace Redis.Application.Data.DriverRepository;
public interface IDriverRepository
{
    public Task UpdateDriverLocation(UpdateDriverLocation driverLocation);
    public Task GetDriverLocation(Guid driverId);
    public Task DeleteDriverLocation(Guid driverId);
}
