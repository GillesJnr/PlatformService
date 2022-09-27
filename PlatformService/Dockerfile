#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#mcr.microsoft.com/dotnet/sdk:3.1

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.csproj ./
RUN dotnet restore 

COPY / ./
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=base /app/out .
ENTRYPOINT ["dotnet", "PlatformService.dll"]
