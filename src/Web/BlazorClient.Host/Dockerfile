#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG NET_IMAGE=6.0-bullseye-slim
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80

# Create a build image and build on it
FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src
COPY ["src/Web/BlazorClient.Host/BlazorClient.Host.csproj", "src/Web/BlazorClient.Host/"]
COPY ["src/Web/BlazorClient/BlazorClient.csproj", "src/Web/BlazorClient/"]
WORKDIR "/src/src/Web/BlazorClient.Host"
FROM build AS publish
RUN dotnet publish "BlazorClient.Host.csproj" -c Release -o /app/publish

# Copy from the build image to the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/ .
ENTRYPOINT ["dotnet", "Microsoft.eShopOnDapr.BlazorClient.Host.dll"]
