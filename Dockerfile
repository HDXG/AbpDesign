# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# 复制 csproj 并恢复依赖项
COPY *.csproj ./
RUN dotnet restore

# 复制其余代码并构建
COPY . ./
RUN dotnet publish -c Release -o out

# 运行应用程序（可选，这里是为了演示如何运行）
FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DesignSetup.Host.dll"]