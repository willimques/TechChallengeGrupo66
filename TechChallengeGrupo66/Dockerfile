# Use uma imagem base do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo .csproj e restaura as dependências
COPY ["API.Producer.csproj", "./"]
RUN dotnet restore "API.Producer.csproj"

# Copia o restante dos arquivos e compila o projeto
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use uma imagem base mais leve para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API.Producer.dll"]

