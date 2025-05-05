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
    class DriverReachedDropOffEventHandler(ISignalRService signalRService) : IConsumer<ReachedDropOffSpotEvent>
    {
        public Task Consume(ConsumeContext<ReachedDropOffSpotEvent> context)
        {
           signalRService.NotidyRiderDriverReachedDropOff(context.Message);
           return Task.CompletedTask;
        }
    }
}
