#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Freezr.Services.Database/Freezr.Services.Database.csproj", "Services/Freezr.Services.Database/"]
COPY ["Freezr.Model/Freezr.Model.csproj", "Freezr.Model/"]
COPY ["Freezr.Entities/Freezr.Entities.csproj", "Freezr.Entities/"]
COPY ["Freezr.Messaging/Freezr.Messaging.csproj", "Freezr.Messaging/"]
COPY ["Freezr.Core/Freezr.Core.csproj", "Freezr.Core/"]
RUN dotnet restore "Services/Freezr.Services.Database/Freezr.Services.Database.csproj"
COPY . .
WORKDIR "/src/Services/Freezr.Services.Database"
RUN dotnet build "Freezr.Services.Database.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Freezr.Services.Database.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Freezr.Services.Database.dll"]