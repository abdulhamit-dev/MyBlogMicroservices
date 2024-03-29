FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLib/*.csproj Shared/SharedLib/
COPY Services/Identity/IdentityAPI/*.csproj Services/Identity/IdentityAPI/
RUN dotnet restore Services/Identity/IdentityAPI/*.csproj
COPY . .
RUN dotnet publish Services/Identity/IdentityAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "IdentityAPI.dll"]