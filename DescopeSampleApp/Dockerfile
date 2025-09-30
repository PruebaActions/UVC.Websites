# Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
# For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build

WORKDIR /app

COPY ["DescopeSampleApp/DescopeSampleApp.csproj", "DescopeSampleApp/"]

RUN dotnet restore DescopeSampleApp/DescopeSampleApp.csproj

COPY . .

RUN dotnet restore DescopeSampleApp/DescopeSampleApp.csproj -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 AS runtime

WORKDIR /inetpub/wwwroot

COPY --from=build /app/DescopeSampleApp/out ./

EXPOSE 80
