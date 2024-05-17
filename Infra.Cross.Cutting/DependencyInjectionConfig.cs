using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           // services.AddScoped<ISqlRepository<Message>, SqlRepository<Message>>(); // Para SQL Server
            
        }


        private static void AddDatabaseServices(IServiceCollection services, IConfiguration configuration)
        {
            //// Configuração para DbContext do SQL Server
            //var sqlConnectionString = configuration.GetConnectionString("SqlServerConnection");
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(sqlConnectionString));

        }
    }
}
