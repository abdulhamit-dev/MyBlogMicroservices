FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80

COPY Services/Cache/CacheAPI/*.csproj Services/Cache/CacheAPI/
RUN dotnet restore Services/Cache/CacheAPI/*.csproj
COPY . .
RUN dotnet publish Services/Cache/CacheAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "CacheAPI.dll"]