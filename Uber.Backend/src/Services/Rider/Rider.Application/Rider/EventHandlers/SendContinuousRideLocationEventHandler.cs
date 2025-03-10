using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using Rider.Application.Data.Services;
using Rider.Domain.Models;

namespace Rider.Application.Rider.EventHandlers
{
    public class SendContinuousRideLocationEventHandler(ISignalRService signalRService) : IConsumer<SendContinuousRideLocationEvent>
    {
        public Task Consume(ConsumeContext<SendContinuousRideLocationEvent> context)
        {
            signalRService.SendTripLocationToRiders(context.Message.Adapt<ContinuousTripLocation>());
            return Task.CompletedTask;
        }
    }
}
