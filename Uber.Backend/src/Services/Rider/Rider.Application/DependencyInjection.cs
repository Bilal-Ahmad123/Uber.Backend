using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rider.Application.BackgroundServices;
using StackExchange.Redis;

namespace Rider.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });
        services.AddHostedService<RiderBackgroundService>();
        return services;
    }

}
