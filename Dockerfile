FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src


COPY ["demo/demo.csproj", "demo/"]
RUN dotnet restore "demo/demo.csproj"


COPY . .
WORKDIR "/src/demo"
RUN dotnet build "demo.csproj" -c Release -o /app/build
RUN dotnet publish "demo.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "demo.dll"]

