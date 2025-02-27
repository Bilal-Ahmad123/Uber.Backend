using BuildingBlocks.Dtos;
using Driver.Application.ConnectionManager;
using Driver.Application.Driver.Commands.UpdateDriverLocation;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Driver.API.SignalREndpoints.Driver;

public class UpdateDriverLocationHub(ISender sender, ILogger<UpdateDriverLocationHub> logger, IConnectionManager connectionManager) :Hub
{
    public async Task UpdateLocation(UpdateLocationDto locationDto)
    {
        await sender.Send(new UpdateDriverLocationCommand(locationDto));    
    }
    public override Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var connectionId = Context.ConnectionId;
        var userId = httpContext?.Request.Query["riderId"].ToString();
        if (Guid.TryParse(userId, out var riderId))
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
