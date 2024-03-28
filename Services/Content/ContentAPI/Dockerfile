FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLib/*.csproj Shared/SharedLib/
COPY Services/Content/ContentAPI/*.csproj Services/Content/ContentAPI/
RUN dotnet restore Services/Content/ContentAPI/*.csproj
COPY . .
RUN dotnet publish Services/Content/ContentAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ContentAPI.dll"]