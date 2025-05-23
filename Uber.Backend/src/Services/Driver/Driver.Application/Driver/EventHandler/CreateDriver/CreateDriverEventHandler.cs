﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.Driver;
using Driver.Application.Services;
using MassTransit;
using DriverEvent = Driver.Domain.Models.Driver.CreateDriver;
namespace Driver.Application.Driver.EventHandler.CreateDriver;
public class CreateDriverEventHandler(IDriverRepository driverRepository) : IConsumer<CreateDriverEvent>
{
    public async Task Consume(ConsumeContext<CreateDriverEvent> context)
    {
        await driverRepository.CreateDriver(context.Message,context.CancellationToken);
    }
}
