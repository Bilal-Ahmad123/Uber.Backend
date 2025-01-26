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
            RuleFor(x => x.User.Email).NotNull().WithMessage("Email is Required");
            RuleFor(x => x.User.FirstName).NotNull().WithMessage("First Name is Required");
            RuleFor(x => x.User.LastName).NotNull().WithMessage("Last Name is Required");
            RuleFor(x => x.User.Country).NotNull().WithMessage("Country is Required");
            RuleFor(x => x.User.ContactNumber).NotNull().WithMessage("Conatct Number is Required");
        }
    }
}
