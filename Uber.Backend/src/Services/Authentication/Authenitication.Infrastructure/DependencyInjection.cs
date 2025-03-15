using System.Reflection;
using Authenitication.Infrastructure.Service;
using Authentication.Application.Data;
using Authentication.Application.Service;
using BuildingBlocks.Messaging.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authenitication.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IRiderService, RiderService>();
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());
        return services;
    }


}
