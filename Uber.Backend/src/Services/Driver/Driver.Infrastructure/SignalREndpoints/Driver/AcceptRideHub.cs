using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Application.Ride.Commands.AcceptRide;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Driver.Infrastructure.SignalREndpoints.Driver
{
    public class AcceptRideHub(ISender sender) : Hub
    {
        public async Task AcceptRide(Guid riderId, Guid driverId)
        {
            await sender.Send(new AcceptRideCommand(new BuildingBlocks.Models.Ride.AcceptRideRequest(driverId, riderId));
        }
    }
}
