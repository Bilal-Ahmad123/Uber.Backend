using Rider.API;
using Rider.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationService(builder.Configuration)
    .AddApiServices(builder.Configuration);
var app = builder.Build();
app.UseApiServices();

app.MapGet("/", () => "Hello World!");

app.Run();
