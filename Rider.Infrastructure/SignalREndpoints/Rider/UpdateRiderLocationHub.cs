using System.Collections.Concurrent;
using BuildingBlocks.Dtos;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Rider.Application.Common;
using Rider.Application.Rider.Commands.UpdateRiderLocation;

namespace Rider.Infrastructure.SignalREndpoints.Rider;

public class UpdateRiderLocationHub(ISender sender,ILogger<UpdateRiderLocationHub> logger, IConnectionManager connectionManager) : Hub
{

    public async Task UpdateLocation(UpdateLocationDto locationDto)
    {
        await sender.Send(new UpdateRiderLocationCommand(locationDto));
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
