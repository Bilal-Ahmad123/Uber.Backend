using Driver.Application.Driver.Commands.UpdateDriverLocation;
using Driver.Application.Dtos.Location;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Driver.API.SignalREndpoints.Driver;

public class UpdateDriverLocationHub(ISender sender):Hub
{
    public async Task UpdateLocation(UpdateLocationDto locationDto)
    {
        await sender.Send(new UpdateDriverLocationCommand(locationDto));    
    }
}
