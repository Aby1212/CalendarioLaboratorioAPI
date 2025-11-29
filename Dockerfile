# Usar imagen base de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiar archivo de proyecto y restaurar dependencias
COPY demo/demo.csproj demo/
RUN dotnet restore "demo/demo.csproj"

# Copiar todo el código fuente
COPY demo/ demo/

# Compilar y publicar
WORKDIR /src/demo
RUN dotnet build "demo.csproj" -c Release -o /app/build
RUN dotnet publish "demo.csproj" -c Release -o /app/publish

# Imagen final runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto
EXPOSE 80
EXPOSE 443

# Variables de entorno opcionales
ENV ASPNETCORE_URLS=http://+:80

# Punto de entrada
ENTRYPOINT ["dotnet", "demo.dll"]

