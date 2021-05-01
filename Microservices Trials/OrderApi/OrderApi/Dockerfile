#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["OrderApi/OrderApi.csproj", "OrderApi/"]
COPY ["OrderApi.Domain/OrderApi.Domain.csproj", "OrderApi.Domain/"]
COPY ["OrderApi.Messaging.Receive/OrderApi.Messaging.Receive.csproj", "OrderApi.Messaging.Receive/"]
COPY ["OrderApi.Service/OrderApi.Service.csproj", "OrderApi.Service/"]
COPY ["OrderAPI.Data/OrderAPI.Data.csproj", "OrderAPI.Data/"]
RUN dotnet restore "OrderApi/OrderApi.csproj"
COPY . .
WORKDIR "/src/OrderApi"
RUN dotnet build "OrderApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApi.dll"]