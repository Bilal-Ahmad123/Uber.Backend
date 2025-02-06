namespace Driver.Application.Vehicle.Commands.CreateVehicle;
public class CreateVehicleCommandHandler : ICommandHandler<CreateVehicleCommand, CreateVehicleResult>
{
    public Task<CreateVehicleResult> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        
    }
}
