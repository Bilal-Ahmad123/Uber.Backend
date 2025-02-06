using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Domain.ValueObjects;

namespace Authentication.Application.Users.Commands.CreateUser.CreateDriver;
public class CreateDriverCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateDriverCommand, CreateDriverResult>
{
    public async Task<CreateDriverResult> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
    {
        var driver = CreateDriver(command.Driver);
        dbContext.Drivers.Add(driver);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateDriverResult(driver.Id.Value);
    }

    public Driver CreateDriver(DriverDto driver)
    {
        return Driver.Create(
          DriverId.of(Guid.NewGuid()),
           driver.Email,
           driver.FirstName,
           driver.LastName,
           driver.Country,
           driver.ContactNumber
         );
    }


}
