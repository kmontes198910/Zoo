FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /zoo

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Zoo.sln" "Zoo.sln"
COPY ["src/Shared/Shared.csproj", "src/Shared/"]
COPY ["src/Zoo/Zoo.csproj", "src/Zoo/"]
COPY ["apps/ZooBackend/ZooBackend.csproj", "apps/ZooBackend/"]

RUN dotnet restore "Zoo.sln"

COPY . .
WORKDIR /zoo/apps/ZooBackend/
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY ./zoo.pfx .
ENTRYPOINT ["dotnet", "ZooBackend.dll"]
