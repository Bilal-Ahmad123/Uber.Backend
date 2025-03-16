using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.Driver;
using Driver.Domain.Models.Driver;

namespace Driver.Application.Services;
public interface IDriverRepository
{
    public Task CreateDriver(CreateDriverEvent driver,CancellationToken cancellationToken);
}
