# Use uma imagem base do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Mostrar o diretório atual (ponto de partida)
RUN echo "Diretório atual:" && pwd

# Copiar o arquivo de solução e os projetos compartilhados
COPY Api.Producer/API.Producer.csproj ./Api.Producer/
COPY Domain/Domain.csproj ./Api.Producer.Domain/
COPY Infra.Cross.Cutting/Infra.Cross.Cutting.csproj ./Api.Producer.Infra/
COPY TestProject/TestProject.csproj ./Api.Producer.TestProject/

RUN echo "Estrutura de diretórios após a cópia inicial:" && ls -lR /App || exit 1


# Restaure as dependências para o projeto de solução
RUN dotnet restore Api.Producer/API.Producer.csproj

# Copiar todos os arquivos restantes
COPY . ./

RUN echo "Listando arquivos em /App/Api.Producer após a cópia completa:" && ls -l Api.Producer || exit 1

# Compile e publique a aplicação Api.Producer
RUN dotnet publish Api.Producer/API.Producer.csproj -c Release -o out

# Verificar se o .dll foi criado corretamente
RUN echo "Conteúdo do diretório /App/out:" && ls -l /App/out

# Use a imagem de runtime do ASP.NET para executar o aplicativo teste
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copiar os arquivos publicados para a imagem de runtime
COPY --from=build-env /App/out /App

# Verificar se o .dll foi copiado corretamente para o diretório de trabalho
RUN echo "Conteúdo do diretório de trabalho após a cópia:" && ls -l /App

# Definir o ponto de entrada
ENTRYPOINT ["dotnet", "/App/API.Producer.dll"]