
using System.Reflection;
using BuildingBlocks.Messaging.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis.Application.BackgroundServices;
using StackExchange.Redis;

namespace Redis.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });
        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());
        services.AddHostedService<DriverRedisBackgroundService>();
        services.AddHostedService<RiderRedisBackgroundService>();
        services.AddHostedService<RideRequestBackgroundService>();

        return services;
    }
}
