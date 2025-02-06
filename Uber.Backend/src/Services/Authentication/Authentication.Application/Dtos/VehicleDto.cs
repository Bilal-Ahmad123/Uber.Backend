using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Dtos;
public record VehicleDto
(
    string VehicleType,
    string VehicleModel,
    DateTime VehicleYear,
    string VehiclePlateNumber,
    string VehicleColor,
    string VehicleMake
);
