# Use the ASP.NET runtime image for the base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Define a configuração de build
ARG BUILD_CONFIGURATION=Release

# Copy project files and restore dependencies
COPY ["TechChallengeGrupo66/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infra.Cross.Cutting/Infra.Cross.Cutting.csproj", "Infra.Cross.Cutting/"]
COPY ["Infra.Data/Infra.Data.csproj", "Infra.Data/"]

RUN dotnet restore "Application/Application.csproj"
RUN dotnet restore "Domain/Domain.csproj"
RUN dotnet restore "Infra.Cross.Cutting/Infra.Cross.Cutting.csproj"
RUN dotnet restore "Infra.Data/Infra.Data.csproj"

# Copy the rest of the source code from each project
COPY ["TechChallengeGrupo66", "Application/"]
COPY ["Domain", "Domain/"]
COPY ["Infra.Cross.Cutting", "Infra.Cross.Cutting/"]
COPY ["Infra.Data", "Infra.Data/"]

# Build the application
WORKDIR "/src/Application"
RUN dotnet build "Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN ls /app/publish  # Adicione esta linha para listar os arquivos

# Final stage to prepare the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]
