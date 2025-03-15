using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.Service;
using Authentication.Domain.ValueObjects;

namespace Authentication.Application.Users.Commands.CreateUser.CreateDriver;
public class CreateDriverCommandHandler(IApplicationDbContext dbContext,IDriverService driverService) : ICommandHandler<CreateDriverCommand, CreateDriverResult>
{
    public async Task<CreateDriverResult> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
    {
        var driver = CreateDriver(command.Driver);
        dbContext.Users.Add(driver);
        await dbContext.SaveChangesAsync(cancellationToken);
        driverService.SendCreateDriverEvent(command.Driver,driver.Id.Value);
        return new CreateDriverResult(driver.Id.Value);
    }

    public User CreateDriver(DriverDto driver)
    {
        return User.Create(
          UserId.Of(Guid.NewGuid()),
           driver.Email
         );
    }
}
