using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rider.Application.Common;
public interface IConnectionManager
{
    void AddConnection(Guid userId, string connectionId);
    void RemoveConnection(string connectionId);
    string? GetConnectionId(Guid userId);
    IReadOnlyDictionary<Guid, string> GetAllConnections();
}
