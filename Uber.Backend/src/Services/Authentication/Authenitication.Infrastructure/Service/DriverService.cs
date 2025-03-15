using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.Dtos;
using Authentication.Application.Service;
using BuildingBlocks.Messaging.Events.Driver;
using MassTransit;

namespace Authenitication.Infrastructure.Service;
public class DriverService(IPublishEndpoint publishEndpoint):IDriverService
{
    public async void SendCreateDriverEvent(DriverDto driverDto, Guid id)
    {
        await publishEndpoint.Publish(MapCreateDriverEvent(driverDto,id));
    }

    private CreateDriverEvent MapCreateDriverEvent(DriverDto driverDto,Guid id)
    {
        return new CreateDriverEvent(
                    driverDto.FirstName,
                    driverDto.LastName,
                    id,
                    driverDto.Country,
                    driverDto.ContactNumber
        );
    }
}
