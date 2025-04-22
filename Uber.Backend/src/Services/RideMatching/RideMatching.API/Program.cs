using RideMatching.API;
using BuildingBlocks.Messaging.MassTransit;
using System.Reflection;
using RideMatching.Application;
using RideMatching.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiService(builder.Configuration)
    .AddInfrastructureService(builder.Configuration)
    .AddApplicationLayer(builder.Configuration);

var app = builder.Build();


app.UseHttpsRedirection();



app.Run();
