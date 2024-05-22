using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infra.Data.Interfaces;
using Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Cross.Cutting
{
    public static class DependencyInjectionConfig

    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositoryServices(services, configuration);
            AddDatabaseServices(services, configuration);
            


            //// Outras categorias de dependências podem ser adicionadas aqui
            return services;
        }

        private static void AddRepositoryServices(IServiceCollection services, IConfiguration configuration)
        {
            // Exemplo de registro de repositórios

            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IDddRepository, DddRepository>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IDddService, DddService>();

            // Registro do FluentValidation
            // Registro do FluentValidation
           // services.AddValidatorsFromAssemblyContaining<ContatoValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();


            // services.AddScoped<ISqlRepository<Message>, SqlRepository<Message>>(); // Para SQL Server

        }


        private static void AddDatabaseServices(IServiceCollection services, IConfiguration configuration)
        {

           // Read the connection string from appsettings.
            var dbConnectionString = configuration.GetConnectionString("DefaultConnection");

            // Inject IDbConnection, with implementation from SqlConnection class.
            services.AddScoped<IDbConnection>((sp) => new SqlConnection(dbConnectionString));


            //// Configuração para DbContext do SQL Server
            //var sqlConnectionString = configuration.GetConnectionString("SqlServerConnection");
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(sqlConnectionString));

        }
    }
}
