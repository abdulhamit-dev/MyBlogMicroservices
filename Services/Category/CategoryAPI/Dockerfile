FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLib/*.csproj Shared/SharedLib/
COPY Services/Category/CategoryAPI/*.csproj Services/Category/CategoryAPI/
RUN dotnet restore Services/Category/CategoryAPI/*.csproj
COPY . .
RUN dotnet publish Services/Category/CategoryAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "CategoryAPI.dll"]