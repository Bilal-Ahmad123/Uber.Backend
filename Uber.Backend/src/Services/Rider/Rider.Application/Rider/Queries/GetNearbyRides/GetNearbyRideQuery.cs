using BuildingBlocks.CQRS;
using FluentValidation;
using Rider.Domain.Models.Vehicle;

namespace Rider.Application.Rider.Queries.GetNearbyRides;
public record GetNearbyRideQuery(Guid RiderId,double Latitude, double Longitude):IQuery<GetNearbyRideQueryResult>;
public record GetNearbyRideQueryResult(IList<NearbyVehicleDetails> NearbyVehicles);
public class GetNearbyRideQueryValidator : AbstractValidator<GetNearbyRideQuery>
{
    public GetNearbyRideQueryValidator()
    {
        RuleFor(x => x.RiderId).NotNull().WithMessage("RiderId is Required");
    }
}
