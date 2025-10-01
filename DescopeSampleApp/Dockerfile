# Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
# For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build

WORKDIR /app

COPY ["DescopeSampleApp.sln", "."]

COPY ["DescopeSampleApp/DescopeSampleApp.csproj", "DescopeSampleApp/"]
COPY ["DescopeSampleApp/packages.config", "DescopeSampleApp/"]

RUN nuget restore DescopeSampleApp/DescopeSampleApp.csproj -PackagesDirectory ./packages

COPY . .

RUN msbuild DescopeSampleApp/DescopeSampleApp.csproj /p:Configuration=Release /p:OutputPath=out

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2022 AS runtime

WORKDIR /inetpub/wwwroot

COPY --from=build /app/DescopeSampleApp/out .

EXPOSE 80
