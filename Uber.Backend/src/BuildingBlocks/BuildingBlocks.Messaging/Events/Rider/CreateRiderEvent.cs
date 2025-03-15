using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.Rider;
public record CreateRiderEvent(
    string FirstName,
    string LastName,
    Guid RiderId,
    string Country,
    string ContactNumber
);
