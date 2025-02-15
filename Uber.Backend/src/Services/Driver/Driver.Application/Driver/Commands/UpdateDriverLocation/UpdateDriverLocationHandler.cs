using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Driver.Application.Driver.Commands.UpdateDriverLocation;
public class UpdateDriverLocationHandler(IPublishEndpoint publishEndpoint, ILogger<UpdateDriverLocationCommand> logger) : ICommandHandler<UpdateDriverLocationCommand, Unit>
{
    public async Task<Unit> Handle(UpdateDriverLocationCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Driver Location Recieved");
        await publishEndpoint.Publish(request, cancellationToken);
        return Unit.Value;
    }
}
