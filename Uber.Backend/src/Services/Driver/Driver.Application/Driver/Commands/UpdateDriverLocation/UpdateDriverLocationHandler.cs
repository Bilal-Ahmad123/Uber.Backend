using BuildingBlocks.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Driver.Application.Driver.Commands.UpdateDriverLocation;
public class UpdateDriverLocationHandler(IPublishEndpoint publishEndpoint, ILogger<UpdateDriverLocationCommand> logger) : ICommandHandler<UpdateDriverLocationCommand, Unit>
{
    public async Task<Unit> Handle(UpdateDriverLocationCommand request, CancellationToken cancellationToken)
    {
        var eventMessage = new UpdateDriverLocationEvent
        (
           request.LocationDto.DriverId,
           request.LocationDto.Latitude,
           request.LocationDto.Longitude
        );
        logger.LogInformation("Driver Location Recieved");
        await publishEndpoint.Publish(eventMessage, cancellationToken);
        return Unit.Value;
    }
}
