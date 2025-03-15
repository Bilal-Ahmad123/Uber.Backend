using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Application.Vehicle.Queries.GetVehicle;
public record GetAllVehiclesQuery():IQuery<GetAllVehiclesResult>;
public record GetAllVehiclesResult(IEnumerable<VehicleDto> Vehicles);
