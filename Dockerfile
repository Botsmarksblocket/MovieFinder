# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY MovieFinder.API/*.csproj ./MovieFinder.API/
COPY MovieFinder.Shared/*.csproj ./MovieFinder.Shared/
RUN dotnet restore ./MovieFinder.API/MovieFinder.API.csproj

# Copy only API + Shared sources
COPY MovieFinder.API ./MovieFinder.API
COPY MovieFinder.Shared ./MovieFinder.Shared

# Publish API
WORKDIR /src/MovieFinder.API
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MovieFinder.API.dll"]