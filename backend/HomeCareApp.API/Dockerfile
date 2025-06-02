FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HomeCareApp.API/HomeCareApp.API.csproj", "HomeCareApp.API/"]
COPY ["HomeCareApp.Application/HomeCareApp.Application.csproj", "HomeCareApp.Application/"]
COPY ["HomeCareApp.Domain/HomeCareApp.Domain.csproj", "HomeCareApp.Domain/"]
COPY ["HomeCareApp.Infrastructure/HomeCareApp.Infrastructure.csproj", "HomeCareApp.Infrastructure/"]
RUN dotnet restore "HomeCareApp.API/HomeCareApp.API.csproj"
COPY . .
WORKDIR "/src/HomeCareApp.API"
RUN dotnet build "./HomeCareApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HomeCareApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeCareApp.API.dll"]
