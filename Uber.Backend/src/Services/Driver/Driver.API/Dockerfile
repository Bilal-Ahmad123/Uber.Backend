# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Driver/Driver.API/Driver.API.csproj", "src/Services/Driver/Driver.API/"]
COPY ["src/BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "src/BuildingBlocks/BuildingBlocks/"]
COPY ["src/Services/Driver/Driver.Application/Driver.Application.csproj", "src/Services/Driver/Driver.Application/"]
COPY ["src/Services/Driver/Driver.Domain/Driver.Domain.csproj", "src/Services/Driver/Driver.Domain/"]
COPY ["src/Services/Driver/Driver.Infrastructure/Driver.Infrastructure.csproj", "src/Services/Driver/Driver.Infrastructure/"]
RUN dotnet restore "./src/Services/Driver/Driver.API/Driver.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Driver/Driver.API"
RUN dotnet build "./Driver.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Driver.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Driver.API.dll"]