using Microsoft.EntityFrameworkCore;
using Vehicle.API;
using Vehicle.Application;
using Vehicle.Infrastructure;
using Vehicle.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationLayer(builder.Configuration)
    .AddInfrastructureLayer(builder.Configuration)
    .AddApiServices(builder.Configuration);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5197, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
    });

    options.ListenAnyIP(5196, listenOptions =>
    {
        listenOptions.UseHttps(); // gRPC requires TLS
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
    });
});

builder.Services.AddGrpc();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.UseAntiforgery();
app.MapGrpcService<MyVehicleService>().EnableGrpcWeb();
app.UseGrpcWeb();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseApiServices();

app.Run();
