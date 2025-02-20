using BuildingBlocks.Dtos;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Rider.Application.Rider.Commands.UpdateRiderLocation;

namespace Rider.API.SignalREndpoints.Rider;

public class UpdateRiderLocationHub(ISender sender) : Hub
{
    public async Task UpdateLocation(UpdateLocationDto locationDto)
    {
        await sender.Send(new UpdateRiderLocationCommand(locationDto));
    }
}
