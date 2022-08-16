# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /var/www
# Copy csproj and restore as distinct layers
COPY PdiApi/*.csproj ./
RUN dotnet restore 
# Copy everything else and build
COPY ./PdiApi ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
EXPOSE 80
EXPOSE 443
WORKDIR /var/www
COPY --from=build-env /var/www/out .
ENTRYPOINT ["dotnet", "PdiApi.dll"]
