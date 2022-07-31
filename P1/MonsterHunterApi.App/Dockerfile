FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MonsterHunterApi.App.csproj", "./"]
RUN dotnet restore "MonsterHunterApi.App.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MonsterHunterApi.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MonsterHunterApi.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "P1.dll"]