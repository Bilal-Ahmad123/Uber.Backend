using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using BuildingBlocks.Models.Driver;
using MassTransit;
using Microsoft.Extensions.Logging;
using Redis.Application.Repositories;

namespace Redis.Application.Consumers;
public class UpdateDriverLocationConsumer(ILogger<UpdateDriverLocationConsumer> logger,IRedisRepository driverRepository) : IConsumer<UpdateUserLocation>
{
    public async Task Consume(ConsumeContext<UpdateUserLocation> context)
    {
        logger.LogInformation("Driver Location Event Recieved");

        await driverRepository.UpdateDriverLocation(context.Message);
    }
}
