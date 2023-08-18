FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://0.0.0.0:5000

EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

COPY . .

WORKDIR "/src/."
RUN dotnet restore "./AzurePipelinesPOC.csproj"
RUN dotnet build "AzurePipelinesPOC.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "AzurePipelinesPOC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AzurePipelinesPOC.dll"]
