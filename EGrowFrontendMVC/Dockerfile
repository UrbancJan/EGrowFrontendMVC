# INSTRUCTIONS on creating a Docker image (Developer PowerShell):
#	1. We create a repo using this command (don't forget the dot at the end): docker build -t egrowmvcservice .
#	2. We save the image file using this command: docker image save -o eGrow_MVC-service_DockerImage.tar egrowmvcservice
# Image gets saved in project folder.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EGrowFrontendMVC/EGrowFrontendMVC.csproj", "EGrowFrontendMVC/"]
RUN dotnet restore "EGrowFrontendMVC/EGrowFrontendMVC.csproj"
COPY . .
WORKDIR "/src/EGrowFrontendMVC"
RUN dotnet build "EGrowFrontendMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EGrowFrontendMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EGrowFrontendMVC.dll"]