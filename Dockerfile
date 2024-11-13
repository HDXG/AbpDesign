FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
EXPOSE 8081
COPY . ./app
WORKDIR /app
ENTRYPOINT ["dotnet", "DesignSetup.Host.dll"]