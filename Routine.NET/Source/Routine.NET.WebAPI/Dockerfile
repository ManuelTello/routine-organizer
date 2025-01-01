FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Routine.NET.WebAPI/Routine.NET.WebAPI.csproj", "Source/Routine.NET.WebAPI/"]
COPY ["Source/Routine.NET.Infrastructure/Routine.NET.Infrastructure.csproj", "Source/Routine.NET.Infrastructure/"]
COPY ["Source/Routine.NET.Application/Routine.NET.Application.csproj", "Source/Routine.NET.Application/"]
RUN dotnet restore "Source/Routine.NET.WebAPI/Routine.NET.WebAPI.csproj"
COPY . .
WORKDIR "/src/Source/Routine.NET.WebAPI"
RUN dotnet build "Routine.NET.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Routine.NET.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Routine.NET.WebAPI.dll"]
