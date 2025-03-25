using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Redis.Application.Repositories;
using Redis.Infrastructure.Repositories;

namespace Redis.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddSingleton<IRedisRepository, RedisRepository>();
        return services;
    }
}
