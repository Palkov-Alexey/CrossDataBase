#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
RUN apt-get update
RUN apt-get install curl
RUN curl -sL https://deb.nodesource.com/setup_22.x | bash
RUN apt-get -y install nodejs

RUN apt-get remove krb5-config krb5-user
RUN apt -y upgrade libkrb5-3
RUN apt-get install -y krb5-config
RUN apt-get install -y krb5-user
RUN apt-get install -y krb5-pkinit
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY /src .
WORKDIR /src/server/CrossDataBase.Server
RUN dotnet build "./CrossDataBase.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CrossDataBase.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY /src/server/CrossDataBase.Server/krb5.conf /etc/krb5.conf

RUN apk add --no-cache \
        krb5-config \
        krb5-user \
        krb5-pkinit
ENTRYPOINT ["dotnet", "CrossDataBase.Server.dll"]
