#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0.13 AS base
WORKDIR /app
EXPOSE 80

# Build libgdiplus with pango
RUN apt-get update && apt-get install  -y --allow-unauthenticated \
     libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev
RUN apt-get update && apt-get install -y libpango1.0-dev 

RUN apt-get install -y --allow-unauthenticated git
RUN git clone https://github.com/mono/libgdiplus.git /libgdiplus
WORKDIR /libgdiplus
RUN ./autogen.sh --with-pango --prefix=/usr
RUN make  
RUN make install

FROM mcr.microsoft.com/dotnet/sdk:5.0.404 AS build
WORKDIR /src
COPY ["Goblin.API/Goblin.API.csproj", "Goblin.API/"]
COPY ["Goblin.Application/Goblin.Application.csproj", "Goblin.Application/"]
COPY ["Ethereum.Infra/Ethereum.Infra.csproj", "Ethereum.Infra/"]
COPY ["GoblinWars.Domain/GoblinWars.Domain.csproj", "GoblinWars.Domain/"]
COPY ["Core.Domain/Core.Domain.csproj", "Core.Domain/"]
COPY ["Auth.Domain/Auth.Domain.csproj", "Auth.Domain/"]
COPY ["GoblinWars.DTO/GoblinWars.DTO.csproj", "GoblinWars.DTO/"]
COPY ["Cloud.Infra/Cloud.Infra.csproj", "Cloud.Infra/"]
COPY ["DB.Infra/DB.Infra.csproj", "DB.Infra/"]
RUN dotnet restore "Goblin.API/Goblin.API.csproj"
COPY . .
WORKDIR "/src/Goblin.API"
RUN dotnet build "Goblin.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Goblin.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Goblin.API.dll"]