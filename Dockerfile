#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./ClinicaAPI/ClinicaAPI.csproj",""]
COPY ["./Infra/Infra.csproj", "../Infra/"]
COPY ["./Domain/Domain.csproj", "../Domain/"]
COPY ["./Application/Application.csproj", "../Application/"]
COPY ["./Service/Service.csproj", "../Service/"]
RUN dotnet restore "ClinicaAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./ClinicaAPI/ClinicaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./ClinicaAPI/ClinicaAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClinicaAPI.dll"]