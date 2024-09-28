# Use uma imagem base do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diretório de trabalho
WORKDIR /src

# Copie todos os arquivos do projeto para o contêiner
COPY . .

# Restaure as dependências para todos os arquivos .csproj encontrados
RUN find . -name "*.csproj" -exec dotnet restore {} \;

# Compile e publique o projeto especificando o arquivo .csproj principal com o caminho relativo correto
WORKDIR /src/TechChallengeGrupo66/API.Producer
RUN dotnet publish -c Release -o /app/publish

# Use uma imagem base mais leve para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API.Producer.dll"]
