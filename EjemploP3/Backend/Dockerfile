# ==========================================
# Etapa 1: Compilación (Usa el SDK completo)
# ==========================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 1. Copiar el archivo del proyecto y restaurar dependencias
COPY ["Backend.csproj", "./"]
RUN dotnet restore "Backend.csproj"

# 2. Copiar el resto de tu código fuente
COPY . .

# 3. Compilar el proyecto en modo Release
RUN dotnet build "Backend.csproj" -c Release -o /app/build

# 4. Publicar los binarios optimizados
FROM build AS publish
RUN dotnet publish "Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ==========================================
# Etapa 2: Producción (Usa el Runtime ligero)
# ==========================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Obligamos a la API a escuchar por HTTP en el puerto 8080
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Copiamos los binarios ya compilados de la etapa anterior
COPY --from=publish /app/publish .

# Definimos el comando de arranque
ENTRYPOINT ["dotnet", "Backend.dll"]