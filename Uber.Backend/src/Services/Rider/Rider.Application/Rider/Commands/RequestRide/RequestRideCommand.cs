using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using BuildingBlocks.Messaging.Events;
using MediatR;

namespace Rider.Application.Rider.Commands.RequestRide;
public record RequestRideCommand(RequestRideEvent RequestRide) :ICommand<Unit>;
