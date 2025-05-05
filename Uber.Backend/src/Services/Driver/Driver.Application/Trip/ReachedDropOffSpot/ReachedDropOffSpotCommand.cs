using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Models.Shared;
using MediatR;

namespace Driver.Application.Trip.ReachedDropOffSpot
{
    public record ReachedDropOffSpotCommand(ReachedDropOffSpotModel Model):ICommand<Unit>;
}
