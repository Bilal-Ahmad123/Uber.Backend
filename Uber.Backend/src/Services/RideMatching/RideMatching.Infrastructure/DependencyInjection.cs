using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideMatching.Application.Rides.Services;
using RideMatching.Infrastructure.Services;

namespace RideMatching.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IRedisService, RedisService>();
        return services;
    }
}
