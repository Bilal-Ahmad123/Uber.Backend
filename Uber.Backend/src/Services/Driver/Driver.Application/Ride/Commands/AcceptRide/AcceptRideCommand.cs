using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Models.Ride;
using MediatR;

namespace Driver.Application.Ride.Commands.AcceptRide;
public record AcceptRideCommand(AcceptRideRequest AcceptRideRequest) : ICommand<Unit>;
