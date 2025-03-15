using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.Driver;
using BuildingBlocks.Messaging.Events.Rider;
using Rider.Application.Data;
using Rider.Application.Repository;
using Rider.Domain.ValueObjects;
using RiderModel = Rider.Domain.Models.Rider.Rider;

namespace Rider.Infrastructure.Repository;
public class RiderRepository(IApplicationDbContext dbContext) : IRiderRepository
{
    public async void CreateRider(CreateRiderEvent rider, CancellationToken cancellationToken)
    {
        dbContext.Riders.Add(MapRiderEvent(rider));
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private RiderModel MapRiderEvent(CreateRiderEvent rider)
    {
        return RiderModel.Create(RiderId.Of(rider.RiderId), rider.FirstName, rider.LastName, rider.Country, rider.ContactNumber);
    }
}
