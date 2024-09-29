#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/host/DesignSetup.Host/DesignSetup.Host.csproj", "src/host/DesignSetup.Host/"]
COPY ["FrameWork/Design.HttpApi/DesignAspNetCore.csproj", "FrameWork/Design.HttpApi/"]
COPY ["src/src/DesignSetup.Application/DesignSetup.Application.csproj", "src/src/DesignSetup.Application/"]
COPY ["FrameWork/Design.Application.Contracts/Design.Application.Contracts.csproj", "FrameWork/Design.Application.Contracts/"]
COPY ["FrameWork/Design.Application/Design.Application.csproj", "FrameWork/Design.Application/"]
COPY ["src/src/DesignSetup.Domain/DesignSetup.Domain.csproj", "src/src/DesignSetup.Domain/"]
COPY ["FrameWork/Design.Domain/Design.Domain.csproj", "FrameWork/Design.Domain/"]
COPY ["src/src/DesignSetup.IInfrastructure/DesignSetup.Infrastructure.csproj", "src/src/DesignSetup.IInfrastructure/"]
COPY ["FrameWork/Design.EntityFrameworkCore/Design.EntityFrameworkCore.csproj", "FrameWork/Design.EntityFrameworkCore/"]
RUN dotnet restore "./src/host/DesignSetup.Host/DesignSetup.Host.csproj"
COPY . .
WORKDIR "/src/src/host/DesignSetup.Host"
RUN dotnet build "./DesignSetup.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DesignSetup.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesignSetup.Host.dll"]