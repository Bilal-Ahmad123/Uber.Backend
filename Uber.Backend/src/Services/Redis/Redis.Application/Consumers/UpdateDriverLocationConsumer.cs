using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Redis.Application.Data;

namespace Redis.Application.Consumers;
public class UpdateDriverLocationConsumer(ILogger<UpdateDriverLocationConsumer> logger,IDriverRepository driverRepository) : IConsumer<UpdateDriverLocation>
{
    public async Task Consume(ConsumeContext<UpdateDriverLocation> context)
    {
        logger.LogInformation("Driver Location Event Recieved");
        await driverRepository.UpdateDriverLocation(context.Message);        
    }
}
