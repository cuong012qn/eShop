#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["eShop.WebApp/eShop.WebApp.csproj", "eShop.WebApp/"]
RUN dotnet restore "eShop.WebApp/eShop.WebApp.csproj"
COPY . .
WORKDIR "/src/eShop.WebApp"
RUN dotnet build "eShop.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eShop.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShop.WebApp.dll"]