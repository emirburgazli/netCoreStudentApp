FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 7046

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StudentApp.csproj", "./"]
RUN dotnet restore "./StudentApp.csproj"
COPY . .
RUN dotnet build "StudentApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StudentApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StudentApp.dll"]