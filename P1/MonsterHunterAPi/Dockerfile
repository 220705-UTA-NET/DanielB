FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env 
WORKDIR /MonsterHunterAPi.API


COPY . .
RUN dotnet restore


RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /MonsterHunterAPi.API/out .
ENTRYPOINT ["dotnet", "MonsterHunterAPi.API.dll"]
EXPOSE 3000

