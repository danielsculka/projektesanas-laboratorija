# Use the .NET 9 SDK for building the API
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY src/ProLab.Shared/*.csproj ./ProLab.Shared/
COPY src/ProLab.Domain/*.csproj ./ProLab.Domain/
COPY src/ProLab.Application/*.csproj ./ProLab.Application/
COPY src/ProLab.Infrastructure/*.csproj ./ProLab.Infrastructure/
COPY src/ProLab.Api/*.csproj ./ProLab.Api/
RUN dotnet restore ./ProLab.Api/ProLab.Api.csproj

# Copy all source code
COPY src/ProLab.Shared ./ProLab.Shared
COPY src/ProLab.Domain ./ProLab.Domain
COPY src/ProLab.Application ./ProLab.Application
COPY src/ProLab.Infrastructure ./ProLab.Infrastructure
COPY src/ProLab.Api ./ProLab.Api

# Build the API project
WORKDIR /src/ProLab.Api
RUN dotnet publish -c Release -o /app/publish

# Use a lightweight .NET 9 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port for the API
EXPOSE 80

# Start the API
ENTRYPOINT ["dotnet", "ProLab.Api.dll"]