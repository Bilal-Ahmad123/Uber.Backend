using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BuildingBlocks.CQRS;
using BuildingBlocks.Dtos;
using MediatR;

namespace Rider.Application.Rider.Commands.UpdateRiderLocation;
public record UpdateRiderLocationCommand(UpdateLocationDto LocationDto):ICommand<Unit>;
