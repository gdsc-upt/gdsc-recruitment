FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GdscRecruitment/GdscRecruitment.csproj", "GdscRecruitment/"]
RUN dotnet restore "GdscRecruitment/GdscRecruitment.csproj"
COPY . .
WORKDIR "/src/GdscRecruitment"
RUN dotnet build "GdscRecruitment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GdscRecruitment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GdscRecruitment.dll"]
