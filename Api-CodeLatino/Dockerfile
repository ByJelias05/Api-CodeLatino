# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia solo el csproj y restaura para cachear dependencias
COPY ["Api-CodeLatino/Api-CodeLatino.csproj", "Api-CodeLatino/"]
RUN dotnet restore "Api-CodeLatino/Api-CodeLatino.csproj"

# Copia todo lo demás y compila
COPY . .
WORKDIR "/src/Api-CodeLatino"
RUN dotnet publish "Api-CodeLatino.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Api-CodeLatino.dll"]
