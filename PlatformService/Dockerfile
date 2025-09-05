FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the project file and restore dependencies first.
# This is a key optimization. As long as your .csproj file doesn't change,
# Docker will use the cached layer for dependencies, making builds faster.
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of your application's source code
COPY . ./

# Publish the application, creating a release build in the 'out' folder
RUN dotnet publish -c Release -o out


# Stage 2: Create the final, smaller runtime image
# The 'FROM' keyword should be uppercase.
# We use the smaller ASP.NET runtime image because it doesn't need the whole SDK.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# CRITICAL FIX: The COPY command needs a source and a destination.
# We are copying from the 'build-env' stage's /app/out directory (the source)
# to the current directory '.' (the destination) in this new stage.
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

# Set the command to run when the container starts
ENTRYPOINT ["dotnet", "PlatformService.dll"]