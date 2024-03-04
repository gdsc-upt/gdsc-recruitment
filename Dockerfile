FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# simplu -> simplu
# .Keycloak -> .Admin
# .Domain -> .Common

COPY ["GdscRecruitment/GdscRecruitment.csproj", "GdscRecruitment/"]
COPY ["GdscRecruitment.Admin/GdscRecruitment.Admin.csproj", "GdscRecruitment.Admin/"]
COPY ["GdscRecruitment.Common/GdscRecruitment.Common.csproj", "GdscRecruitment.Common/"]
# COPY ["Smartrite-Backend.OldDomain/Smartrite-Backend.OldDomain.csproj", "Smartrite-Backend.OldDomain/"]

RUN dotnet restore "GdscRecruitment/GdscRecruitment.csproj"

COPY . .

WORKDIR /src/GdscRecruitment
RUN dotnet build "GdscRecruitment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GdscRecruitment.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:80

EXPOSE 80
EXPOSE 443

COPY docker-entrypoint.sh /usr/bin/docker-entrypoint.sh
RUN chmod +x /usr/bin/docker-entrypoint.sh
ENTRYPOINT ["docker-entrypoint.sh"]

# Link image with github repo
LABEL org.opencontainers.image.source=https://github.com/gdsc-upt/gdsc-recruitment.git