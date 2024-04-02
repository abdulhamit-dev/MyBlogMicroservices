FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLib/*.csproj Shared/SharedLib/
COPY Services/TextSearch/TextSearchAPI/*.csproj Services/TextSearch/TextSearchAPI/
RUN dotnet restore Services/TextSearch/TextSearchAPI/*.csproj
COPY . .
RUN dotnet publish Services/TextSearch/TextSearchAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "TextSearchAPI.dll"]