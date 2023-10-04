FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "BrewUp/BrewUp.csproj"
COPY . .
WORKDIR "/src/BrewUp"
RUN dotnet build "BrewUp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrewUp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrewUp.dll"]