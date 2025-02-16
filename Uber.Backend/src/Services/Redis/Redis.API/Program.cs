using Redis.Application;
using StackExchange.Redis;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationService(builder.Configuration);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
