using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Events;

namespace Rider.Application.Services;
public interface IRedisProtoClientService
{
    List<Guid> GetNearbyDrivers(UpdateUserLocation riderLocation);
}
