FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SvitloServerApi/SvitloServerApi.csproj", "SvitloServerApi/"]
RUN dotnet restore "SvitloServerApi/SvitloServerApi.csproj"
COPY . .
WORKDIR "/src/SvitloServerApi"
RUN dotnet build "SvitloServerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SvitloServerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SvitloServerApi.dll"]