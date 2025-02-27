FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY ["DevStage.API/", "DevStage.API/"]
COPY ["DevStage.Domain/", "DevStage.Domain/"]
COPY ["DevStage.Communication/", "DevStage.Communication/"]
COPY ["DevStage.Application/", "DevStage.Application/"]
COPY ["DevStage.Exception/", "DevStage.Exception/"]
COPY ["DevStage.Infrastructure/", "DevStage.Infrastructure/"]

WORKDIR /app/

RUN dotnet restore
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "DevStage.API.dll"]
