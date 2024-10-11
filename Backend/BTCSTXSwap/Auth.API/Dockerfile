#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Auth.API/Auth.API.csproj", "Auth.API/"]
COPY ["Goblin.Application/Goblin.Application.csproj", "Goblin.Application/"]
COPY ["Ethereum.Infra/Ethereum.Infra.csproj", "Ethereum.Infra/"]
COPY ["GoblinWars.Domain/GoblinWars.Domain.csproj", "GoblinWars.Domain/"]
COPY ["Core.Domain/Core.Domain.csproj", "Core.Domain/"]
COPY ["DB.Infra/DB.Infra.csproj", "DB.Infra/"]
COPY ["Auth.Domain/Auth.Domain.csproj", "Auth.Domain/"]
COPY ["GoblinWars.DTO/GoblinWars.DTO.csproj", "GoblinWars.DTO/"]
RUN dotnet restore "Auth.API/Auth.API.csproj"
COPY . .
WORKDIR "/src/Auth.API"
RUN dotnet build "Auth.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Auth.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.API.dll"]