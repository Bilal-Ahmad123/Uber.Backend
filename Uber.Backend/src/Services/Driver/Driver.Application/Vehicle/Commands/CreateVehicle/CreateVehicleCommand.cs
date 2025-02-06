
using FluentValidation;

namespace Driver.Application.Vehicle.Commands.CreateVehicle;
public record CreateVehicleCommand(VehicleDto Vehicle):ICommand<CreateVehicleResult>;
public record CreateVehicleResult(Guid Id);

public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.Vehicle.DriverId).NotNull().WithMessage("Driver Id is Required");
        RuleFor(x => x.Vehicle.VehicleMake).NotNull().WithMessage("Vehicle Make is Required");
        RuleFor(x => x.Vehicle.VehicleModel).NotNull().WithMessage("Vehicle Model is Required");
        RuleFor(x => x.Vehicle.VehicleYear).NotNull().WithMessage("Vehicle Year is Required");
        RuleFor(x => x.Vehicle.VehicleColor).NotNull().WithMessage("Vehicle Color is Required");
        RuleFor(x => x.Vehicle.VehiclePlateNumber).NotNull().WithMessage("Vehicle Plate Number is Required");
        RuleFor(x => x.Vehicle.VehicleType).NotNull().WithMessage("Vehicle Type is Required");
    }
}
