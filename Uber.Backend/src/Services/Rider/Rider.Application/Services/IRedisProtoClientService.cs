using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rider.Application.Services;
public interface IRedisProtoClientService
{
    List<Guid> GetNearbyDrivers();
}
