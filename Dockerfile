# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY *.sln .
COPY MovieFinder.API/*.csproj ./MovieFinder.API/
COPY MovieFinder.Shared/*.csproj ./MovieFinder.Shared/
COPY MovieFinder.Client/*.csproj ./MovieFinder.Client/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /src/MovieFinder.API
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MovieFinder.API.dll"]