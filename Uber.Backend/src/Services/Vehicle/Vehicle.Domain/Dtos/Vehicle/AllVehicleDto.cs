using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Domain.Dtos.Vehicle
{
   public record AllVehicleDto(
    string VehicleName,
    int MaxSeats,
    decimal BaseFare,
    decimal RatePerKM,
    string ImageUrl
   );
}
