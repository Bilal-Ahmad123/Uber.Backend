using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;
using MediatR;

namespace Driver.Application.Ride.Commands.AcceptRide;
public class AcceptRideCommandHandler(IPublishEndpoint publishEndpoint) : ICommandHandler<AcceptRideCommand, Unit>
{
    public async Task<Unit> Handle(AcceptRideCommand request, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish(request.AcceptRideRequest.Adapt<AcceptRideRequestEvent>());
        return Unit.Value;
    }
}
