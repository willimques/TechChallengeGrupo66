# Use uma imagem base do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Mostrar o diret�rio atual (ponto de partida)
RUN echo "Diret�rio atual:" && pwd

# Copiar o arquivo de solu��o e os projetos compartilhados
COPY Api.Producer/API.Producer.csproj ./Api.Producer/
COPY Domain/Domain.csproj ./Api.Producer.Domain/
COPY Infra.Cross.Cutting/Infra.Cross.Cutting.csproj ./Api.Producer.Infra/
COPY TestProject/TestProject.csproj ./Api.Producer.TestProject/

RUN echo "Estrutura de diret�rios ap�s a c�pia inicial:" && ls -lR /App || exit 1


# Restaure as depend�ncias para o projeto de solu��o
RUN dotnet restore Api.Producer/API.Producer.csproj

# Copiar todos os arquivos restantes
COPY . ./

RUN echo "Listando arquivos em /App/Api.Producer ap�s a c�pia completa:" && ls -l Api.Producer || exit 1

# Compile e publique a aplica��o Api.Producer
RUN dotnet publish Api.Producer/API.Producer.csproj -c Release -o out

# Verificar se o .dll foi criado corretamente
RUN echo "Conte�do do diret�rio /App/out:" && ls -l /App/out

# Use a imagem de runtime do ASP.NET para executar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copiar os arquivos publicados para a imagem de runtime
COPY --from=build-env /App/out /App

# Verificar se o .dll foi copiado corretamente para o diret�rio de trabalho
RUN echo "Conte�do do diret�rio de trabalho ap�s a c�pia:" && ls -l /App

# Definir o ponto de entrada
ENTRYPOINT ["dotnet", "/App/API.Producer.dll"]