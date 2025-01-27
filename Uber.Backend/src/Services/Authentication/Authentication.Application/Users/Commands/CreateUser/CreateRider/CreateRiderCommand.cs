using System.Windows.Input;
using BuildingBlocks.CQRS;

namespace Authentication.Application.Users.Commands.CreateUser.CreateRider
{
    public record CreateRiderCommand(RiderDto Rider) : ICommand<CreateRiderResult>;
    public record CreateRiderResult(Guid Id);
    public class CreateRiderCommandValidator : AbstractValidator<CreateRiderCommand>
    {
        public CreateRiderCommandValidator()
        {
            RuleFor(x => x.Rider.Email).NotNull().WithMessage("Email is Required");
            RuleFor(x => x.Rider.FirstName).NotNull().WithMessage("First Name is Required");
            RuleFor(x => x.Rider.LastName).NotNull().WithMessage("Last Name is Required");
            RuleFor(x => x.Rider.Country).NotNull().WithMessage("Country is Required");
            RuleFor(x => x.Rider.ContactNumber).NotNull().WithMessage("Conatct Number is Required");
        }
    }
}
