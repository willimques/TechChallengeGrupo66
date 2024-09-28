# Use uma imagem base do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o arquivo .csproj e restaure as dependências
COPY ["TechChallengeGrupo66/API.Producer.csproj", "./"]
RUN dotnet restore "./API.Producer.csproj"

# Copie todos os arquivos e compile o projeto
COPY TechChallengeGrupo66/. ./  # Copia todo o conteúdo da pasta
WORKDIR /src
RUN dotnet publish "./API.Producer.csproj" -c Release -o /app/publish

# Use uma imagem base do .NET Runtime para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API.Producer.dll"]
