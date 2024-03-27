FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SharedLib/*.csproj Shared/SharedLib/
COPY Services/Comment/CommentAPI/*.csproj Services/Comment/CommentAPI/
RUN dotnet restore Services/Comment/CommentAPI/*.csproj
COPY . .
RUN dotnet publish Services/Comment/CommentAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "CommentAPI.dll"]