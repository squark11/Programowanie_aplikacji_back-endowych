using MassTransit;
using ServiceApp.Library.DbAccess;
using System.Net;
using WorkerService;
using WorkerService.Library.Data;
using WorkerService.Library.Helpers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IBusConsumer, BusConsumer>();
        services.AddHostedService<Worker>();
        services.AddScoped<ISqlDataAccess, SqlDataAccess>();
        services.AddScoped<ILogsData, LogsData>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<IBusConsumer>(u => u.UseRateLimit(1, TimeSpan.FromSeconds(5)));
            x.UsingRabbitMq((context, cfg) =>
            {
                var ip = Dns.GetHostEntry("rabbitmq").AddressList.FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                cfg.Host(ip.ToString());
                //cfg.Host("localhost");

                cfg.ConfigureEndpoints(context);
            });

        });
    })
    .Build();

await host.RunAsync();
