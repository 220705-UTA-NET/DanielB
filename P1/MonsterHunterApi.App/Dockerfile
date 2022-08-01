FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

COPY . ./
RUN dotnet restore 

RUN dotnet publish -c Release -o out

EXPOSE 3000
ENTRYPOINT ["dotnet", "MonsterHunterApi.App.dll"]
