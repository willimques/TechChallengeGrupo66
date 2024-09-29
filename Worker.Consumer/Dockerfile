# Use uma imagem base do .NET SDK para compilar o projeto
<<<<<<< HEAD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Mostrar o diretório atual (ponto de partida)
RUN echo "Diretório atual:" && pwd

# Copiar o arquivo de solução e os projetos compartilhados
COPY Worker.Consumer/Worker.Consumer.csproj ./Worker.Consumer/
COPY Domain/Domain.csproj ./Worker.Consumer.Domain/
COPY Infra.Cross.Cutting/Infra.Cross.Cutting.csproj ./Worker.Consumer.Infra/
COPY TestProject/TestProject.csproj ./Worker.Consumer.TestProject/
RUN echo "Estrutura de diretórios após a cópia inicial:" && ls -lR /App || exit 1


# Restaure as dependências para o projeto de solução
RUN dotnet restore Worker.Consumer/Worker.Consumer.csproj

# Copiar todos os arquivos restantes
COPY . ./

RUN echo "Listando arquivos em /App/Worker.Consumer após a cópia completa:" && ls -l Worker.Consumer || exit 1

# Compile e publique a aplicação Worker.Consumer
RUN dotnet publish Worker.Consumer/Worker.Consumer.csproj -c Release -o out

# Verificar se o .dll foi criado corretamente
RUN echo "Conteúdo do diretório /App/out:" && ls -l /App/out

# Use a imagem de runtime do ASP.NET para executar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copiar os arquivos publicados para a imagem de runtime
COPY --from=build-env /App/out /App

# Verificar se o .dll foi copiado corretamente para o diretório de trabalho
RUN echo "Conteúdo do diretório de trabalho após a cópia:" && ls -l /App

# Definir o ponto de entrada
ENTRYPOINT ["dotnet", "/App/Worker.Consumer.dll"]
=======
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diretÃ³rio de trabalho
WORKDIR /src

# Copie todos os arquivos para o diretÃ³rio de trabalho
COPY . .

# Use o comando find para localizar e restaurar o .csproj
RUN dotnet restore $(find . -name "*.csproj")

# Compile e publique o projeto
RUN dotnet publish $(find . -name "*.csproj") -c Release -o /app/publish

# Use uma imagem base mais leve para executar a aplicaÃ§Ã£o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "$(find . -name '*.dll')"]
>>>>>>> 5ada46a561dc2f07c7f7bf008e8701001b842fc1
