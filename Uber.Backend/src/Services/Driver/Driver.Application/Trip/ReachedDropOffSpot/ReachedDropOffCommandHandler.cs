using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Models.Shared;
using Mapster;
using MassTransit;
using MediatR;

namespace Driver.Application.Trip.ReachedDropOffSpot;
public class ReachedDropOffCommandHandler(IPublishEndpoint publishEndpoint) : ICommandHandler<ReachedDropOffSpotCommand, Unit>
{
    public async Task<Unit> Handle(ReachedDropOffSpotCommand request, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish(request.Model.Adapt<ReachedDropOffSpotEvent>());
        return Unit.Value;
    }
}
