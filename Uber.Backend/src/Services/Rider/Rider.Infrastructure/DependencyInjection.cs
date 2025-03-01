
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rider.Application.Common;
using Rider.Application.Data.Services;
using Rider.Infrastructure.BackgroundServices;
using Rider.Infrastructure.Connection;
using Rider.Infrastructure.Services;
using Rider.Infrastructure.SignalREndpoints.Rider;
using StackExchange.Redis;

namespace Rider.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionManager, ConnectionManager>();
            services.AddSingleton<IRiderLocationService, RiderLocationService>();
            services.AddSingleton<ISignalRService, SignalRService>();
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
            });
            services.AddHostedService<RiderBackgroundService>();
            return services;
        }

        public static WebApplication AddApiServices(this WebApplication app)
        {
            app.MapHub<UpdateRiderLocationHub>("/riderhub");
            return app;
        }
    }
}
