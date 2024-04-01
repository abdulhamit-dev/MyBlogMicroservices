FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80

COPY GatewayAPI/*.csproj GatewayAPI/
RUN dotnet restore GatewayAPI/*.csproj
COPY . .
RUN dotnet publish GatewayAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "GatewayAPI.dll"]