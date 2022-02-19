#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Clockwerkz.Common/Clockwerkz.Common.csproj", "Clockwerkz.Common/"]
COPY ["Clockwerkz.Application/Clockwerkz.Application.csproj", "Clockwerkz.Application/"]
COPY ["Clockwerkz.Domain/Clockwerkz.Domain.csproj", "Clockwerkz.Domain/"]
COPY ["Clockwerkz.Infrastructure/Clockwerkz.Infrastructure.csproj", "Clockwerkz.Infrastructure/"]
COPY ["Clockwerkz.Persistence/Clockwerkz.Persistence.csproj", "Clockwerkz.Persistence/"]
COPY ["Clockwerkz.Blazor.Web/Clockwerkz.Blazor.Web.csproj", "Clockwerkz.Blazor.Web/"]

RUN dotnet restore "Clockwerkz.Blazor.Web/Clockwerkz.Blazor.Web.csproj"
COPY . .
WORKDIR "/src/Clockwerkz.Blazor.Web"
RUN dotnet build "Clockwerkz.Blazor.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clockwerkz.Blazor.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clockwerkz.Blazor.Web.dll"]