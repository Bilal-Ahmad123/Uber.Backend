using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Dtos;
public record UpdateLocationDto(Guid UserId, double Latitude, double Longitude);
