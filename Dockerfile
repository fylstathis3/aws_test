FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["aws_test.csproj", "aws_test/"]
RUN dotnet restore "aws_test/aws_test.csproj"
COPY . .
WORKDIR "/src/aws_test"
RUN dotnet build "aws_test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aws_test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aws_test.dll"]
