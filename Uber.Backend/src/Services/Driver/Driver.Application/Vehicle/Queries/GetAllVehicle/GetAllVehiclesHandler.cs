using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Application.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Driver.Application.Vehicle.Queries.GetVehicle;
public class GetAllVehiclesHandler(IApplicationDbContext dbContext) : IQueryHandler<GetAllVehiclesQuery, GetAllVehiclesResult>
{
    public async Task<GetAllVehiclesResult> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = (await dbContext.Vehicles.ToListAsync(cancellationToken)).Adapt<List<VehicleDto>>();
        return new GetAllVehiclesResult(vehicles);
    }
}

