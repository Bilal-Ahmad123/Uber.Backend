using Microsoft.Extensions.Configuration;
using Uber.Backend.Presentation.SignalR.Extensions;
using Uber.Backend.Presentation.SignalR.Hubs;
using Uber.Infrastructure.Data;
using StackExchange.Redis;
using ServiceStack.Redis;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices()
.AddSignalRPresentation();

builder.Services.AddSingleton<IRedisClientsManager>(c =>
{
    var config = builder.Configuration.GetSection("Redis").Get<string[]>();
    return new RedisManagerPool(config);
});

// Add Redis as a singleton
//if (redisConnectionString != null)
//{
//    builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
//        ConnectionMultiplexer.Connect(redisConnectionString));
//}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});



var app = builder.Build();

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();


app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });



app.Map("/", () => Results.Redirect("/api"));
app.MapGet("/test-redis", (IRedisClientsManager redisClientsManager) =>
{
    using (IRedisClient redis = redisClientsManager.GetClient())
    {
        var item = redis.As<string>();
        item.SetValue("hello","world");

    }
    return Results.Ok($"Key 'testKey' has value:");
});
app.MapEndpoints();
app.MapHubEndpoints();

app.Run();

public partial class Program { }
