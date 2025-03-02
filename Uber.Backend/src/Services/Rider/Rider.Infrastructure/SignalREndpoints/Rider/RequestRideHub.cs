using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Rider.Application.Rider.Commands.RequestRide;
using Rider.Domain.Models;

namespace Rider.Infrastructure.SignalREndpoints.Rider
{
    class RequestRideHub(ISender sender, ILogger<RequestRideHub> logger) :Hub
    {
        public async Task RequestRide(RequestRide requestRide)
        {
            await sender.Send(new RequestRideCommand(new RequestRideEvent {
                RiderId = requestRide.RiderId,
                PickUpLocation = new BuildingBlocks.Models.Rider.PickUpLocation(requestRide.PickupLongitude,requestRide.PickupLatitude),
                DropOffLocation = new BuildingBlocks.Models.Rider.DropOffLocation(requestRide.DropoffLongitude, requestRide.DropoffLatitude)
            }));
        }
    }
}
