using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Models.Rider;
using MediatR;

namespace RideMatching.Domain.Notifications
{
    public record RiderRequestedRideNotification:INotification
    {
        public Guid RideId  { get; set; }
        public Guid RiderId { get; init; }
        public PickUpLocation? PickUpLocation { get; set; }
        public DropOffLocation? DropOffLocation { get; set; }
    }
}
