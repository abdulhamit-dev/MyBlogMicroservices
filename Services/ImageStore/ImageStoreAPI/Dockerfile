FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLib/*.csproj Shared/SharedLib/
COPY Services/ImageStore/ImageStoreAPI/*.csproj Services/ImageStore/ImageStoreAPI/
RUN dotnet restore Services/ImageStore/ImageStoreAPI/*.csproj
COPY . .
RUN dotnet publish Services/ImageStore/ImageStoreAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ImageStoreAPI.dll"]