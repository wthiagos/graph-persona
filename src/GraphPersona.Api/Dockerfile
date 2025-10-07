# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
RUN addgroup --system appgroup && adduser --system --ingroup appgroup --home /home/appuser appuser
WORKDIR /app
EXPOSE 8080
USER appuser

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /workspace

# Copy solution and project files first (for better layer caching)
COPY ["Directory.Packages.props", "./"]
COPY ["GraphPersona.sln", "./"]
COPY ["src/GraphPersona.Api/GraphPersona.csproj", "src/GraphPersona.Api/"]

RUN dotnet restore "GraphPersona.sln"

# Copy the rest of the source
COPY . .

WORKDIR "/workspace/src/GraphPersona.Api"
RUN dotnet build "GraphPersona.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS migrations
RUN dotnet tool install --global dotnet-ef

ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations bundle \
    --project /workspace/src/GraphPersona.Api/GraphPersona.csproj \
    --startup-project /workspace/src/GraphPersona.Api/GraphPersona.csproj \
    -o /app/migration-bundle \
    --self-contained \
    -r linux-x64

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GraphPersona.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphPersona.dll"]