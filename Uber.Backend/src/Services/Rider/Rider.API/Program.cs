using Microsoft.EntityFrameworkCore;
using Rider.API;
using Rider.Application;
using Rider.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationService(builder.Configuration)
    .AddApiServices(builder.Configuration)
    .AddInfrastructureService(builder.Configuration);
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //dbContext.Database.Migrate();
}
app.UseApiServices();
app.AddApiServices();

app.MapGet("/", () => "Hello World!");

app.Run();
