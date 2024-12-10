using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Uber.Backend.Presentation.SignalR.Hubs;

namespace Uber.Backend.Presentation.SignalR.Extensions;
public static class EndPointRouteBuilderExtension
{
    public static IEndpointRouteBuilder MapHubEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapHub<LocationHub>("/" + nameof(LocationHub));
        return endpointRouteBuilder;
    }
}
