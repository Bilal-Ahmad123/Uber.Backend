using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rider.Application.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Rider.Application.ServiceManager;
public class ConnectionManager:IConnectionManager
{
    private readonly ConcurrentDictionary<Guid, string> _connectedClients = new();

    public void AddConnection(Guid userId, string connectionId)
    {
        _connectedClients.AddOrUpdate(userId, connectionId,(key,existing)=>connectionId);
    }

    public void RemoveConnection(string connectionId)
    {
        var rider = _connectedClients.FirstOrDefault(x => x.Value == connectionId);
        if (rider.Key != Guid.Empty)
        {
            _connectedClients.TryRemove(rider.Key, out _);
        }
    }

    public string? GetConnectionId(Guid userId)
    {
        return _connectedClients.TryGetValue(userId, out var connectionId) ? connectionId : null;
    }

    public IReadOnlyDictionary<Guid, string> GetAllConnections()
    {
        return _connectedClients;
    }
}
