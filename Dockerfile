FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /
COPY ["Mwnz.Company.Facade.WebApi/Mwnz.Company.Facade.WebApi.csproj", "Mwnz.Company.Facade.WebApi/"]
COPY ["Mwnz.Company.Source.Xml.Api.Client/Mwnz.Company.Source.Xml.Api.Client.csproj", "Mwnz.Company.Source.Xml.Api.Client/"]
RUN dotnet restore "Mwnz.Company.Facade.WebApi/Mwnz.Company.Facade.WebApi.csproj"
COPY . .
WORKDIR "/Mwnz.Company.Facade.WebApi"
RUN dotnet build "Mwnz.Company.Facade.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mwnz.Company.Facade.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
ENV TZ=FAKENZ+13
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mwnz.Company.Facade.WebApi.dll"]