# Etapa 1: Build con Maven
FROM maven:3.8.6-openjdk-11 AS build
WORKDIR /app

# Copiar archivos de configuración de Maven
COPY pom.xml .
COPY mvnw .
COPY mvnw.cmd .
COPY .mvn .mvn

# Dar permisos de ejecución al wrapper de Maven
RUN chmod +x mvnw

# Descargar dependencias (esto se cachea si pom.xml no cambia)
RUN ./mvnw dependency:go-offline -B

# Copiar el código fuente
COPY src ./src
COPY Data ./Data
COPY Entidades ./Entidades
COPY Servicios ./Servicios

# Compilar la aplicación
RUN ./mvnw clean package -DskipTests

# Etapa 2: Runtime
FROM openjdk:11-jre-slim
WORKDIR /app

# Copiar el JAR compilado desde la etapa de build
COPY --from=build /app/target/*.jar app.jar

# Exponer el puerto (Spring Boot usa 8080 por defecto)
EXPOSE 8080

# Variables de entorno
ENV JAVA_OPTS="-Xmx512m -Xms256m"
ENV SERVER_PORT=8080

# Ejecutar la aplicación
ENTRYPOINT ["sh", "-c", "java $JAVA_OPTS -jar app.jar"]

