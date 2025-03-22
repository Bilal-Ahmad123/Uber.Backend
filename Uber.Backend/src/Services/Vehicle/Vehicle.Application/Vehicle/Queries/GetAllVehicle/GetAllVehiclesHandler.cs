
using Mapster;

namespace Vehicle.Application.Vehicle.Queries.GetVehicle;
public class GetAllVehiclesHandler(IApplicationDbContext dbContext) : IQueryHandler<GetAllVehiclesQuery, GetAllVehiclesResult>
{
    public async Task<GetAllVehiclesResult> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = (await dbContext.Vehicles.ToListAsync(cancellationToken)).Adapt<List<VehicleDto>>();
        return new GetAllVehiclesResult(vehicles);
    }
}

