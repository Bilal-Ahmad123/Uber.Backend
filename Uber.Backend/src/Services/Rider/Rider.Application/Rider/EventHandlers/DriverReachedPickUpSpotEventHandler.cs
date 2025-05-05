using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using MassTransit;
using Rider.Application.Data.Services;

namespace Rider.Application.Rider.EventHandlers
{
    class DriverReachedPickUpSpotEventHandler(ISignalRService signalRService) : IConsumer<ReachedPickUpSpotEvent>
    {
        public Task Consume(ConsumeContext<ReachedPickUpSpotEvent> context)
        {
            signalRService.NotifyRiderDriverReached(context.Message);
            return Task.CompletedTask;
        }
    }
}
