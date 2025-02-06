# Usar la imagen base de .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Definir el directorio de trabajo
WORKDIR /app

# Copiar el archivo .csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el código fuente
COPY . ./

# Publicar la aplicación
RUN dotnet publish -c Release -o out

# Usar la imagen base de ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Copiar los archivos publicados desde el contenedor de construcción
COPY --from=build /app/out .

# Definir el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "HotelApp.Api.dll"]
