using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Driver.Application.Vehicle.Queries.CheckVehicle;

public class CheckVehicleCreatedHandler(IApplicationDbContext dbContext) : IQueryHandler<CheckVehicleCreatedQuery, CheckVehicleCreatedResult>
{
    public async Task<CheckVehicleCreatedResult> Handle(CheckVehicleCreatedQuery query, CancellationToken cancellationToken)
    {
        var vehicle = await dbContext.Vehicles.FirstOrDefaultAsync(x => x.DriverId.Equals(query.DriverId));
        if (vehicle is not null)
        {
            return new CheckVehicleCreatedResult(true);
        }
        return new CheckVehicleCreatedResult(false);
    }
}
