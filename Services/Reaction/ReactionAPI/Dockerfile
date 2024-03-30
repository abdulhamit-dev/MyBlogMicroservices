FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLib/*.csproj Shared/SharedLib/
COPY Services/Reaction/ReactionAPI/*.csproj Services/Reaction/ReactionAPI/
RUN dotnet restore Services/Reaction/ReactionAPI/*.csproj
COPY . .
RUN dotnet publish Services/Reaction/ReactionAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ReactionAPI.dll"]