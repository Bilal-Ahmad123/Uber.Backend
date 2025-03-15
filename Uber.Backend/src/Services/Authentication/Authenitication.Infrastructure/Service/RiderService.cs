using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.Dtos;
using Authentication.Application.Service;
using BuildingBlocks.Messaging.Events.Driver;
using BuildingBlocks.Messaging.Events.Rider;
using MassTransit;

namespace Authenitication.Infrastructure.Service;
internal class RiderService(IPublishEndpoint publishEndpoint) : IRiderService
{
    public async void SendCreateRiderEvent(RiderDto rider, Guid id)
    {
        await publishEndpoint.Publish(MapCreateDriverEvent(rider, id));
    }

    private CreateRiderEvent MapCreateDriverEvent(RiderDto driverDto, Guid id)
    {
        return new CreateRiderEvent(
                    driverDto.FirstName,
                    driverDto.LastName,
                    id,
                    driverDto.Country,
                    driverDto.ContactNumber
        );
    }
}
