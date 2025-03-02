using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using MediatR;
using Microsoft.Extensions.Logging;
using Rider.Application.Data.Services;
using Rider.Application.Rider.Commands.UpdateRiderLocation;

namespace Rider.Application.Rider.Commands.RequestRide;
public class RequestRideCommandHandler(ILogger<RequestRideCommandHandler> logger,IRide ride) : ICommandHandler<RequestRideCommand, Unit>
{
    public async Task<Unit> Handle(RequestRideCommand request, CancellationToken cancellationToken)
    {
       await ride.RequestRide(request.RequestRide);
        return Unit.Value;
    }
}
