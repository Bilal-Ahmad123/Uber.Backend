using BuildingBlocks.Events;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Rider.Application.Common;
using Rider.Application.Data.Services;
using Rider.Domain.Models;
using Rider.Infrastructure.SignalREndpoints.Rider;


namespace Rider.Infrastructure.Services;
public class SignalRService(IConnectionManager connectionManager, IHubContext<UpdateRiderLocationHub> hubContext,ILogger<SignalRService> logger) : ISignalRService
{
    public async void SendDriverLocationToRiders(DriverPositionWithRiders driverPositionWithRiders)
    {
        foreach (var item in driverPositionWithRiders.Riders)
        {
            var connectionId = connectionManager.GetConnectionId(item);
            if(connectionId != null)
            {
                try
                {
                   await hubContext.Clients.Client(connectionId).SendAsync("DriverLocationUpdate", 
                       driverPositionWithRiders.UserId,
                       driverPositionWithRiders.Longitude,
                       driverPositionWithRiders.Latitude,
                       driverPositionWithRiders.VehicleType
                    );
                }
                catch(Exception e)
                {
                    logger.LogError(e.ToString());
                }
            }
        }
    }

    public async void NotifyRiderRideAccepted(Guid riderId)
    {
        var connectionId = connectionManager.GetConnectionId(riderId);
        if (connectionId != null)
        {
            try
            {
                await hubContext.Clients.Client(connectionId).SendAsync("RideAccepted", riderId);
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }
        }
    }
}
