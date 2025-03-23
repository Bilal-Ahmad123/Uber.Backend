using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace BuildingBlocks.Common;
public static class Helper
{
    public static T Deserializer<T>(string message)
    {
        return JsonSerializer.Deserialize<T>(message)!;
    }
}
