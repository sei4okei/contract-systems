FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["ContractSystems/ContractSystems.csproj", "ContractSystems/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "ContractSystems/ContractSystems.csproj"
COPY . .
WORKDIR "/src/ContractSystems"
RUN dotnet build "ContractSystems.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish "ContractSystems.csproj" -c Release -o /app --no-restore

FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContractSystems.dll"]