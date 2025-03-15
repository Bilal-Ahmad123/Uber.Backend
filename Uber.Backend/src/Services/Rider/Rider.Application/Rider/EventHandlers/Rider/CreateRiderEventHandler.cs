using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.Rider;
using MassTransit;
using Rider.Application.Repository;

namespace Rider.Application.Rider.EventHandlers.Rider;
public class CreateRiderEventHandler(IRiderRepository riderRepository) : IConsumer<CreateRiderEvent>
{
    public Task Consume(ConsumeContext<CreateRiderEvent> context)
    {
        riderRepository.CreateRider(context.Message, context.CancellationToken);
        return Task.CompletedTask;
    }
}
