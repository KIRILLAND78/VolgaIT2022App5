#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM alpine

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VolgaIT2022App5.csproj", "."]
RUN dotnet restore "./VolgaIT2022App5.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "VolgaIT2022App5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VolgaIT2022App5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VolgaIT2022App5.dll"]