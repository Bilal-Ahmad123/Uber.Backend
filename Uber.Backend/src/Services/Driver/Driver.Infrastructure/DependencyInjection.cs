using Driver.Application.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Driver.Application.Services;
using Driver.Infrastructure.Services;
using Driver.Application.ConnectionManager;
using Driver.Infrastructure.Connection;
using Driver.Infrastructure.BackgroundServices;
using Microsoft.AspNetCore.Builder;
using Driver.API.SignalREndpoints.Driver;
namespace Driver.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddSingleton<IConnectionManager, ConnectionManager>();
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddSingleton<ISignalRService, SignalRService>();
        services.AddHostedService<DriverRedisBackgroundService>();
        return services;
    }

    public static WebApplication AddHub(this WebApplication app)
    {
        app.MapHub<UpdateDriverLocationHub>("/driverhub");
        return app;
    }
}
