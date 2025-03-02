using BuildingBlocks.Exceptions.Handler;

namespace RideMatching.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks();
        return services;
    }
}
