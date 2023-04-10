using CustomerService.Consumers;
using CustomerService.Primitives;
using MassTransit;
using RabbitMQ.Client;

namespace CustomerService.Infrastructure;

public static class MassTransitConfigurations
{
    public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqSettings = configuration.GetSection(RabbitMqSettings.SectionName).Get<RabbitMqSettings>();
        
        services.AddMassTransit(x =>
        {
            //x.AddConsumers(typeof(Program).Assembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqSettings.Host, "/", h =>
                {
                    h.Username(rabbitMqSettings.UserName);
                    h.Password(rabbitMqSettings.Password);
                });

                cfg.ReceiveEndpoint("CustomerService.CustomerCreated", x =>
                {
                    x.Consumer<CustomerCreatedIntegrationEventConsumer>();
                    x.Bind(rabbitMqSettings.DefaultExchangeName, e =>
                    {
                        e.ExchangeType = ExchangeType.Direct;
                    });
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
