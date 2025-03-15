using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.Driver;
public record CreateDriverEvent(
    string FirstName,
    string LastName,
    Guid DriverId,
    string Country,
    string ContactNumber
);

