#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ContactManagement.UI/ContactManagement.UI.csproj", "src/ContactManagement.UI/"]
COPY ["src/ContactManagement.Data/ContactManagement.Data.csproj", "src/ContactManagement.Data/"]
COPY ["src/ContactManagement.Domain/ContactManagement.Domain.csproj", "src/ContactManagement.Domain/"]
RUN dotnet restore "src/ContactManagement.UI/ContactManagement.UI.csproj"
COPY . .
WORKDIR "/src/src/ContactManagement.UI"
RUN dotnet build "ContactManagement.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactManagement.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactManagement.UI.dll"]