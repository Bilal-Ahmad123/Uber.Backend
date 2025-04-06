using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;
using Rider.Domain.Models.Rider;

namespace Rider.Application.Services;
public interface IRedisProtoClientService
{
    NearbyDriverResponse GetNearbyDrivers(UpdateUserLocation riderLocation);
}
