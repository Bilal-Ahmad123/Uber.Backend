using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.Data;
using Authentication.Application.Service;
using Authentication.Domain.ValueObjects;
using BuildingBlocks.CQRS;
using MediatR;

namespace Authentication.Application.Users.Commands.CreateUser.CreateRider;
public class CreateRiderHandler(IApplicationDbContext dbContext,IRiderService riderService) : ICommandHandler<CreateRiderCommand, CreateRiderResult>
{
    public async Task<CreateRiderResult> Handle(CreateRiderCommand request, CancellationToken cancellationToken)
    {
        var rider = CreateNewRider(request.Rider);
        dbContext.Users.Add(rider);
        await dbContext.SaveChangesAsync(cancellationToken);
        riderService.SendCreateRiderEvent(request.Rider, rider.Id.Value);
        return new CreateRiderResult(rider.Id.Value);
    }

    private User CreateNewRider(RiderDto riderDto)
    {
        var rider = User.Create(
            UserId.Of(Guid.NewGuid()),
            riderDto.Email
        );
        return rider;
    }
}
