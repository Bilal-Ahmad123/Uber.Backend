using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Users.Commands.CreateUser.CreateDriver;
public  record CreateDriverCommand(DriverDto Driver):ICommand<CreateDriverResult>;
public record CreateDriverResult(Guid Id);

public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
{
    public CreateDriverCommandValidator()
    {
        RuleFor(x=>x.Driver.Email).NotNull().WithMessage("Email is Required");
        RuleFor(x => x.Driver.FirstName).NotNull().WithMessage("First Name is Required");
        RuleFor(x => x.Driver.LastName).NotNull().WithMessage("Last Name is Required");
        RuleFor(x => x.Driver.Country).NotNull().WithMessage("Country is Required");
        RuleFor(x => x.Driver.ContactNumber).NotNull().WithMessage("Conatct Number is Required");
    }
}
