using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Dtos;
using FluentValidation;
using MediatR;

namespace Driver.Application.Driver.Commands.UpdateDriverLocation;
public record UpdateDriverLocationCommand(UpdateLocationDto LocationDto) : ICommand<Unit>;

public class  UpdateDriverLocationCommandValidator:AbstractValidator<UpdateDriverLocationCommand>
{
    public UpdateDriverLocationCommandValidator()
    {
        RuleFor(x => x.LocationDto.UserId).NotNull().WithMessage("Driver Id is Required");
        RuleFor(x => x.LocationDto.Latitude).NotNull().WithMessage("Latitude is Required");
        RuleFor(x => x.LocationDto.Longitude).NotNull().WithMessage("Longitude is Required");
    }
}
