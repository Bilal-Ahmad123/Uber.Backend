using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Application.Vehicle.Queries.CheckVehicle;
public record CheckVehicleCreatedQuery(Guid DriverId):IQuery<CheckVehicleCreatedResult>;
public record CheckVehicleCreatedResult(bool Exists);

