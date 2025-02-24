using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BuildingBlocks.Events.Driver
{
    public record RideRequestRecievedEvent():INotification;
}
