#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GoblinWars.BackgroundService/GoblinWars.BackgroundService.csproj", "GoblinWars.BackgroundService/"]
COPY ["Auth.Domain/Auth.Domain.csproj", "Auth.Domain/"]
COPY ["Core.Domain/Core.Domain.csproj", "Core.Domain/"]
COPY ["GoblinWars.DTO/GoblinWars.DTO.csproj", "GoblinWars.DTO/"]
COPY ["Goblin.Application/Goblin.Application.csproj", "Goblin.Application/"]
COPY ["Cloud.Infra/Cloud.Infra.csproj", "Cloud.Infra/"]
COPY ["GoblinWars.Domain/GoblinWars.Domain.csproj", "GoblinWars.Domain/"]
COPY ["DB.Infra/DB.Infra.csproj", "DB.Infra/"]
COPY ["Ethereum.Infra/Ethereum.Infra.csproj", "Ethereum.Infra/"]
RUN dotnet restore "GoblinWars.BackgroundService/GoblinWars.BackgroundService.csproj"
COPY . .
WORKDIR "/src/GoblinWars.BackgroundService"
RUN dotnet build "GoblinWars.BackgroundService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoblinWars.BackgroundService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoblinWars.BackgroundService.dll"]
