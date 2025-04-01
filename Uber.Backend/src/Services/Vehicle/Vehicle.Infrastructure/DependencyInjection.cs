
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vehicle.Application.Data;
using Vehicle.Application.Repositories;
using Vehicle.Application.Services;
using Vehicle.Infrastructure.Repository.Vehicle;
using Vehicle.Infrastructure.Services;

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
        services.AddSingleton<IFileService, FileService>();
        services.AddScoped<IAllVehiclesRepository, AllVehiclesRepository>();
        services.AddHttpContextAccessor();
        return services;
    }
}
