using BuildingBlocks.Events;
using Driver.Application.Data.Repository;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using DriverLocation = BuildingBlocks.Events.UpdateDriverLocation;
namespace Driver.Application.Driver.Commands.UpdateDriverLocation;
public class UpdateDriverLocationHandler(ILogger<UpdateDriverLocationCommand> logger,IDriverUpdateLocationRepository repository) : ICommandHandler<UpdateDriverLocationCommand, Unit>
{
    public  Task<Unit> Handle(UpdateDriverLocationCommand request, CancellationToken cancellationToken)
    {
        var eventMessage = new DriverLocation
        (
           request.LocationDto.DriverId,
           request.LocationDto.Latitude,
           request.LocationDto.Longitude
        );
        logger.LogInformation("Driver Location Recieved");
        repository.SendDriverLocationUpdate(eventMessage);
        return Task.FromResult(Unit.Value);
    }
}
