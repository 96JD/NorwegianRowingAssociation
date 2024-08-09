FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /norwegian-rowing-association

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["NorwegianRowingAssociation.csproj", "."]

RUN dotnet restore "./NorwegianRowingAssociation.csproj"

COPY . .

WORKDIR "/src/."

RUN dotnet build "NorwegianRowingAssociation.csproj" -c Release -o /norwegian-rowing-association/build

FROM build AS publish

RUN dotnet publish "NorwegianRowingAssociation.csproj" -c Release -o /norwegian-rowing-association/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /norwegian-rowing-association

COPY --from=publish /norwegian-rowing-association/publish .

ENTRYPOINT ["dotnet", "NorwegianRowingAssociation.dll"]