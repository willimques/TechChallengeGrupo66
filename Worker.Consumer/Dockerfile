# Use uma imagem base do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo .csproj e restaura as dependências
COPY ["Worker.Consumer.csproj", "./"]
RUN dotnet restore "Worker.Consumer.csproj"

# Copia o restante dos arquivos e compila o projeto
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use uma imagem base mais leve para executar a aplicação
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Worker.Consumer.dll"]
