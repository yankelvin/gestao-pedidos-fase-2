#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["GestaoPedidos.Web.csproj", "src/GestaoPedidos.Web/"]
#RUN dotnet restore "./src/GestaoPedidos.Web/./GestaoPedidos.Web.csproj"
#COPY . .
#WORKDIR "/src/GestaoPedidos.Web"
#RUN dotnet build "./GestaoPedidos.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./GestaoPedidos.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "GestaoPedidos.Web.dll"]



FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "./GestaoPedidos.Web/GestaoPedidos.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./GestaoPedidos.Web/GestaoPedidos.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestaoPedidos.Web.dll"]