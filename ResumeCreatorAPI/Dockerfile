FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5074

ENV ASPNETCORE_URLS=http://+:5074

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ResumeCreatorAPI/ResumeCreatorAPI.csproj", "ResumeCreatorAPI/"]
RUN dotnet restore "ResumeCreatorAPI/ResumeCreatorAPI.csproj"
COPY . .
WORKDIR "/src/ResumeCreatorAPI"
RUN dotnet build "ResumeCreatorAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ResumeCreatorAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResumeCreatorAPI.dll"]
