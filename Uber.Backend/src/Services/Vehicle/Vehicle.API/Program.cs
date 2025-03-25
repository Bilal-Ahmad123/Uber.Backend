using Vehicle.Application;
using Vehicle.Infrastructure;
using Vehicle.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationLayer(builder.Configuration)
    .AddInfrastructureLayer(builder.Configuration);

builder.Services.AddGrpc();

var app = builder.Build();


app.MapGrpcService<MyVehicleService>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
