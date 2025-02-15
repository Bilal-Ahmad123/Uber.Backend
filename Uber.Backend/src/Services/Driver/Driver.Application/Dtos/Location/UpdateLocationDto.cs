using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Application.Dtos.Location;
public record UpdateLocationDto(Guid DriverId, double Latitude, double Longitude);
