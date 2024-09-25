using Infra.Cross.Cutting;
using MassTransit;
using Worker.Consumer;
using Worker.Consumer.Events;

var builder = Host.CreateApplicationBuilder(args);

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var filaAdd = configuration.GetSection("MassTransit")["FilaAdd"] ?? string.Empty;
        var filaUpdate = configuration.GetSection("MassTransit")["FilaUpdate"] ?? string.Empty;
        var filaDelete = configuration.GetSection("MassTransit")["FilaDelete"] ?? string.Empty;
        var servidor = configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
        var usuario = configuration.GetSection("MassTransit")["Usuario"] ?? string.Empty;
        var senha = configuration.GetSection("MassTransit")["Senha"] ?? string.Empty;
        services.AddHostedService<WorkerConsumer>();
        services.AddProjectDependencies(configuration);

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(servidor, "/", h =>
                {
                    h.Username(usuario);
                    h.Password(senha);
                });
                cfg.ReceiveEndpoint(filaAdd, e =>
                {
                    e.Consumer<ContatoAddConsumer>(context);

                    e.PrefetchCount = 1;

                    e.UseCircuitBreaker(cb => {
                        cb.ResetInterval = TimeSpan.FromSeconds(10);
                        cb.ActiveThreshold = 1;
                        cb.TrackingPeriod = TimeSpan.FromSeconds(10);
                    });
                });
                cfg.ReceiveEndpoint(filaUpdate, e =>
                {
                    e.Consumer<ContatoUpdateConsumer>(context);

                    e.PrefetchCount = 1;

                    e.UseCircuitBreaker(cb => {
                        cb.ResetInterval = TimeSpan.FromSeconds(10);
                        cb.ActiveThreshold = 1;
                        cb.TrackingPeriod = TimeSpan.FromSeconds(10);
                    });
                });
                cfg.ReceiveEndpoint(filaDelete, e =>
                {
                    e.Consumer<ContatoDeleteConsumer>(context);

                    e.PrefetchCount = 1;

                    e.UseCircuitBreaker(cb => {
                        cb.ResetInterval = TimeSpan.FromSeconds(10);
                        cb.ActiveThreshold = 1;
                        cb.TrackingPeriod = TimeSpan.FromSeconds(10);
                    });
                });
                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<ContatoAddConsumer>();
            x.AddConsumer<ContatoUpdateConsumer>();
            x.AddConsumer<ContatoDeleteConsumer>();
        });
    })
    .Build();



host.Run();
