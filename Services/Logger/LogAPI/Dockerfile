FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLib/*.csproj Shared/SharedLib/
COPY Services/Logger/LogAPI/*.csproj Services/Logger/LogAPI/
RUN dotnet restore Services/Logger/LogAPI/*.csproj
COPY . .
RUN dotnet publish Services/Logger/LogAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "LogAPI.dll"]