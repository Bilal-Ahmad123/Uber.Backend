using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Application.ConnectionManager;
public interface IConnectionManager
{
    void AddConnection(Guid userId, string connectionId);
    void RemoveConnection(string connectionId);
    string? GetConnectionId(Guid userId);
    IReadOnlyDictionary<Guid, string> GetAllConnections();
}
