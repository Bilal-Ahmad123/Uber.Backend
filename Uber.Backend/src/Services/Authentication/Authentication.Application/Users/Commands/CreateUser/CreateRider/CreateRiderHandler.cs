using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.Data;
using BuildingBlocks.CQRS;
using MediatR;

namespace Authentication.Application.Users.Commands.CreateUser.CreateRider;
public class CreateRiderHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateRiderCommand, CreateRiderResult>
{
    public async Task<CreateRiderResult> Handle(CreateRiderCommand request, CancellationToken cancellationToken)
    {
        var rider = CreateNewRider(request.Rider);
        dbContext.Riders.Add(rider);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateRiderResult(rider.Id.Value);
    }

    private Rider CreateNewRider(RiderDto riderDto)
    {
        var rider = Rider.Create(
            riderDto.FirstName,
            riderDto.LastName,
            riderDto.Email,
            riderDto.ContactNumber,
            riderDto.Country
            );
        return rider;
    }
}
