using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis;
using RideMatching.Application.Rides.Services;
using RideMatching.Infrastructure.Services;
using StackExchange.Redis;

namespace RideMatching.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IRedisProtoClientService, RedisProtoClientService>();
        services.AddGrpcClient<RedisService.RedisServiceClient>(o =>
        {
            o.Address = new Uri(configuration["GrpcSettings:RedisUrl"]!);
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            return handler;
        });
        return services;
    }
}
