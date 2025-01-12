# Use the .NET 9 SDK for building the API
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY src/ProLab.Shared/*.csproj ./ProLab.Shared/
COPY src/ProLab.App/*.csproj ./ProLab.App/
RUN dotnet restore ./ProLab.App/ProLab.App.csproj

# Copy all source code
COPY src/ProLab.Shared ./ProLab.Shared
COPY src/ProLab.App ./ProLab.App

# Build the Blazor WebAssembly app
WORKDIR /src/ProLab.App
RUN dotnet publish -c Release -o /app/build

# Serve static files
FROM alpine:3.17
WORKDIR /app

# Copy the published static files from the build stage
COPY --from=build /app/build/wwwroot .

CMD ["sh", "-c", "echo 'Static files are ready in /app' && sleep infinity"]