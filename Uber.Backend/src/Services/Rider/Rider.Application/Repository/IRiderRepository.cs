using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.Driver;
using BuildingBlocks.Messaging.Events.Rider;

namespace Rider.Application.Repository;
public interface IRiderRepository
{
    public void CreateRider(CreateRiderEvent driver, CancellationToken cancellationToken);
}
