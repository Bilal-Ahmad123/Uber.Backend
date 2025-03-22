
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vehicle.Application.Data;
using Vehicle.Application.Repositories;
using Vehicle.Infrastructure.Repository.Vehicle;

namespace Vehicle.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        return services;
    }
}
