#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FrontEnd.Api/FrontEnd.Api.csproj", "FrontEnd.Api/"]
RUN dotnet restore "FrontEnd.Api/FrontEnd.Api.csproj"
COPY . .
WORKDIR "/src/FrontEnd.Api"
RUN dotnet build "FrontEnd.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrontEnd.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrontEnd.Api.dll"]
