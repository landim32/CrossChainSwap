#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

ENV ASPNET_ENV Docker

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
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

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BTCSTXSwap.API/BTCSTXSwap.API.csproj", "BTCSTXSwap.API/"]
COPY ["BTCSTXSwap.Application/BTCSTXSwap.Application.csproj", "BTCSTXSwap.Application/"]
COPY ["BTCSTXSwap.Domain/BTCSTXSwap.Domain.csproj", "BTCSTXSwap.Domain/"]
COPY ["Core.Domain/Core.Domain.csproj", "Core.Domain/"]
COPY ["BTCSTXSwap.DTO/BTCSTXSwap.DTO.csproj", "BTCSTXSwap.DTO/"]
COPY ["DB.Infra/DB.Infra.csproj", "DB.Infra/"]
RUN dotnet restore "BTCSTXSwap.API/BTCSTXSwap.API.csproj"
COPY . .
WORKDIR "/src/BTCSTXSwap.API"
RUN dotnet build "BTCSTXSwap.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BTCSTXSwap.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BTCSTXSwap.API.dll"]