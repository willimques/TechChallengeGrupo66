# Use uma imagem base do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diretório de trabalho
WORKDIR /src

# Copie todos os arquivos do projeto para o contêiner
COPY . .

# Encontre e restaure as dependências para todos os arquivos .csproj encontrados
RUN dotnet restore $(find . -name "*.csproj")

# Encontre o projeto principal (assumindo que há apenas um .csproj para publicação) e publique-o
RUN dotnet publish $(find . -name "*.csproj" | head -n 1) -c Release -o /app/publish

# Use uma imagem base mais leve para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "$(ls *.dll | head -n 1)"]

