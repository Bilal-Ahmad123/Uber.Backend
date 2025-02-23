using Rider.API;
using Rider.Application;
using Rider.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationService(builder.Configuration)
    .AddApiServices(builder.Configuration)
    .AddInfrastructureService(builder.Configuration);
var app = builder.Build();
app.UseApiServices();
app.AddApiServices();

app.MapGet("/", () => "Hello World!");

app.Run();
