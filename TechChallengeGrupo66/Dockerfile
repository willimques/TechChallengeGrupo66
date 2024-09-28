# Use uma imagem base do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diretório de trabalho
WORKDIR /src

# Copie todos os arquivos para o diretório de trabalho
COPY . .

# Use o comando find para localizar e restaurar o .csproj
RUN dotnet restore $(find . -name "*.csproj")

# Compile e publique o projeto
RUN dotnet publish $(find . -name "*.csproj") -c Release -o /app/publish

# Use uma imagem base mais leve para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "$(find . -name '*.dll')"]
