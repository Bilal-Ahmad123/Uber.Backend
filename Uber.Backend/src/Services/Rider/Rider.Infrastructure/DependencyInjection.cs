
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rider.Application.Common;
using Rider.Application.Data;
using Rider.Application.Data.Services;
using Rider.Application.Repository;
using Rider.Infrastructure.BackgroundServices;
using Rider.Infrastructure.Connection;
using Rider.Infrastructure.Repository;
using Rider.Infrastructure.Services;
using Rider.Infrastructure.SignalREndpoints.Rider;
using StackExchange.Redis;

namespace Rider.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddSingleton<IConnectionManager, ConnectionManager>();
            services.AddSingleton<IRiderLocationService, RiderLocationService>();
            services.AddSingleton<ISignalRService, SignalRService>();
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
            });
            services.AddHostedService<RiderBackgroundService>();
            services.AddScoped<IRide, Ride>();
            services.AddScoped<IRiderRepository, RiderRepository>();
            return services;
        }

        public static WebApplication AddApiServices(this WebApplication app)
        {
            app.MapHub<UpdateRiderLocationHub>("/riderhub");
            return app;
        }
    }
}
