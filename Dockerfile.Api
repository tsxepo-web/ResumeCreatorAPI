FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["ResumeCreatorAPI/ResumeCreatorAPI.csproj", "ResumeCreatorAPI/"]
COPY ["ResumeCreator.Tests/ResumeCreator.Tests.csproj", "ResumeCreator.Tests/"]

RUN dotnet restore "ResumeCreatorAPI/ResumeCreatorAPI.csproj"

COPY . .

RUN dotnet publish "ResumeCreatorAPI/ResumeCreatorAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5074
ENV ASPNETCORE_URLS=http://+:5074

ENTRYPOINT ["dotnet", "ResumeCreatorAPI.dll"]
