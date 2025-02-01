using Authenitication.Infrastructure;
using Authentication.API;
using Authentication.Application;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5231); // Ensures the app listens on all network interfaces
});
builder.Services.AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);
var app = builder.Build();
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()); 
app.UseApiServices();

app.MapGet("/", () => "Hello World!");

app.Run();
