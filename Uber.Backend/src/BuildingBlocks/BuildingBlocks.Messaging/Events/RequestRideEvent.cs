using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Models.Rider;

namespace BuildingBlocks.Messaging.Events
{
    public record RequestRideEvent
    {
        public Guid RideId => Guid.NewGuid();
        public Guid RiderId { get; init; }
        public PickUpLocation? PickUpLocation { get; set; }
        public DropOffLocation? DropOffLocation { get; set; }
    }
}
