#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroRabbit.Transfer.Api/MicroRabbit.Transfer.Api.csproj", "MicroRabbit.Transfer.Api/"]
RUN dotnet restore "MicroRabbit.Transfer.Api/MicroRabbit.Transfer.Api.csproj"
COPY . .
WORKDIR "/src/MicroRabbit.Transfer.Api"
RUN dotnet build "MicroRabbit.Transfer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroRabbit.Transfer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroRabbit.Transfer.Api.dll"]