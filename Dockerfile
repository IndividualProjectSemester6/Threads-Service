#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . .

# Restore project
RUN dotnet restore "src/ThreadsService.API/ThreadsService.API.csproj"

# Build project
RUN dotnet build "src/ThreadsService.API/ThreadsService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/ThreadsService.API/ThreadsService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThreadsService.API.dll"]