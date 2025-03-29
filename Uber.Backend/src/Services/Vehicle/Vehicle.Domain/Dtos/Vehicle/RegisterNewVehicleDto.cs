using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Vehicle.Domain.Dtos.Vehicle;
public record RegisterNewVehicleDto(
    string VehicleName,
    int MaxSeats,
    decimal BaseFare,
    decimal RatePerKM,
    IFormFile Image
);
