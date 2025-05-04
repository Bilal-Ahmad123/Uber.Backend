using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using MediatR;

namespace Driver.Application.Trip.ReachedPickUpSpot;
public class ReachedPickUpSpotCommandHandler(IPublishEndpoint publishEndpoint) : ICommandHandler<ReachedPickUpSpotCommand, Unit>
{
    public async Task<Unit> Handle(ReachedPickUpSpotCommand request, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish(request.Spot.Adapt<ReachedPickUpSpotEvent>());
        return Unit.Value;
    }
}
