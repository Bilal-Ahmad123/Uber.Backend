using System.Collections.Concurrent;
using BuildingBlocks.Dtos;
using BuildingBlocks.Messaging.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Rider.Application.Common;
using Rider.Application.Rider.Commands.RequestRide;
using Rider.Application.Rider.Commands.UpdateRiderLocation;
using Rider.Domain.Models;

namespace Rider.Infrastructure.SignalREndpoints.Rider;

public class UpdateRiderLocationHub(ISender sender,ILogger<UpdateRiderLocationHub> logger, IConnectionManager connectionManager) : Hub
{

    public async Task UpdateLocation(UpdateLocationDto locationDto)
    {
        await sender.Send(new UpdateRiderLocationCommand(locationDto));
    }

    public async Task RequestRide(RequestRide requestRide)
    {
        logger.LogInformation("RequestRide: {requestRide}", requestRide);
        await sender.Send(new RequestRideCommand(new RequestRideEvent
        {
            RiderId = requestRide.RiderId,
            PickUpLocation = new BuildingBlocks.Models.Rider.PickUpLocation(requestRide.PickupLongitude, requestRide.PickupLatitude),
            DropOffLocation = new BuildingBlocks.Models.Rider.DropOffLocation(requestRide.DropoffLongitude, requestRide.DropoffLatitude)
        }));
    }

    public override Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var connectionId = Context.ConnectionId;
        var userId = httpContext?.Request.Query["riderId"].ToString();
        if(Guid.TryParse(userId, out var riderId))
        {
           connectionManager.AddConnection(riderId, connectionId);
        }
        else
        {
            logger.LogError("Invalid riderId: {riderId}", userId);
        }

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;
        connectionManager.RemoveConnection(connectionId);
        return base.OnDisconnectedAsync(exception);
    }
}
