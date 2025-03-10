using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using MediatR;

namespace Driver.Application.Ride.Commands.SendContinuousTripLocation;
internal class SendContinuousRideLocationCommandHandler(IPublishEndpoint publishEndpoint) : ICommandHandler<SendContinuousRideLocationCommand, Unit>
{
    public async Task<Unit> Handle(SendContinuousRideLocationCommand request, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish(request.Adapt<SendContinuousRideLocationEvent>());
        return Unit.Value;
    }
}
