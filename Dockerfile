# Use the official .NET image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
RUN dotnet restore "WebApplication1/WebApplication1.csproj"

# Copy the rest of the application files (including wwwroot)
COPY . .

# Set the working directory to the app folder
WORKDIR "/src/WebApplication1"

# Build and publish the application
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish --no-restore

# Create the final runtime image
FROM base AS final
WORKDIR /app

# Fix the incorrect stage reference here!
COPY --from=build /app/publish .  

# Ensure the wwwroot folder is copied over
COPY ./WebApplication1/wwwroot /app/wwwroot

ENTRYPOINT ["dotnet", "WebApplication1.dll"]
