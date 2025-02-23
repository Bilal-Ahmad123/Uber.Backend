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
    public void SendDriverLocationToRiders(DriverPositionWithRiders driverPositionWithRiders)
    {
        foreach (var item in driverPositionWithRiders.Riders)
        {
            var connectionId = connectionManager.GetConnectionId(item);
            if(connectionId != null)
            {
                try
                {
                    hubContext.Clients.Client(connectionId).SendAsync("DriverLocationUpdate", 
                        driverPositionWithRiders.UserId,
                        driverPositionWithRiders.Longitude,
                        driverPositionWithRiders.Latitude
                    );
                }
                catch(Exception e)
                {
                    logger.LogError(e.ToString());
                }
            }
        }
    }
}
