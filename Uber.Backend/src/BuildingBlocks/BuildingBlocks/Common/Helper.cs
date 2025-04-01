using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace BuildingBlocks.Common;
public static class Helper
{
    public static T Deserializer<T>(string message)
    {
        return JsonSerializer.Deserialize<T>(message)!;
    }

    public static string GetVehicleUrl(HttpContext? httpContext)
    {
        return $"{httpContext?.Request.Scheme}://192.168.18.65:5196/";
    }
}
