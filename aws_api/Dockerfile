FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["aws_api/aws_api.csproj", "aws_api/"]
RUN dotnet restore "aws_api/aws_api.csproj"
COPY . .
WORKDIR "/src/aws_api"
RUN dotnet build "aws_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aws_api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aws_api.dll"]
