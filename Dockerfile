# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar todo el proyecto
COPY . .

# Navegar a la carpeta demo y restaurar dependencias
WORKDIR /app/demo
RUN dotnet restore

# Compilar y publicar
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copiar los archivos publicados
COPY --from=build /app/publish .

# Exponer puertos
EXPOSE 80
EXPOSE 443

# Variables de entorno
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "demo.dll"]

