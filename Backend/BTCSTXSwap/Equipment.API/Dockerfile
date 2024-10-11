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
COPY ["Equipment.API/Equipment.API.csproj", "Equipment.API/"]
COPY ["GoblinWars.Domain/GoblinWars.Domain.csproj", "GoblinWars.Domain/"]
COPY ["Auth.Domain/Auth.Domain.csproj", "Auth.Domain/"]
COPY ["Core.Domain/Core.Domain.csproj", "Core.Domain/"]
COPY ["GoblinWars.DTO/GoblinWars.DTO.csproj", "GoblinWars.DTO/"]
COPY ["Goblin.Application/Goblin.Application.csproj", "Goblin.Application/"]
COPY ["Cloud.Infra/Cloud.Infra.csproj", "Cloud.Infra/"]
COPY ["DB.Infra/DB.Infra.csproj", "DB.Infra/"]
COPY ["Ethereum.Infra/Ethereum.Infra.csproj", "Ethereum.Infra/"]
RUN dotnet restore "Equipment.API/Equipment.API.csproj"
COPY . .
WORKDIR "/src/Equipment.API"
RUN dotnet build "Equipment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Equipment.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Equipment.API.dll"]
