﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.Driver;
using Driver.Application.Data;
using Driver.Application.Services;
using Driver.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using DriverModel = Driver.Domain.Models.Driver.Driver;

namespace Driver.Infrastructure.Repository.Driver;
public class DriverRepository(IApplicationDbContext dbContext,ILogger<DriverRepository> logger) : IDriverRepository
{
    public async Task CreateDriver(CreateDriverEvent driver, CancellationToken cancellationToken)
    {
        try
        {
            dbContext.Drivers.Add(MapDriverEvent(driver));
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch(Exception e)
        {
            logger.LogError(e.Message);
        }
    }

    private DriverModel MapDriverEvent(CreateDriverEvent driver)
    {
      return DriverModel.Create(DriverId.Of(driver.DriverId), driver.FirstName, driver.LastName, driver.Country, driver.ContactNumber);
    }
}
