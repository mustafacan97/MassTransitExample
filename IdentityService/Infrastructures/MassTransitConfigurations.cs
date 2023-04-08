using MassTransit;
using IdentityService.Primitives;
using IdentityService.Events;

namespace IdentityService.Infrastructures;

public static class MassTransitConfigurations
{
    public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqSettings = configuration.GetSection(RabbitMqSettings.SectionName).Get<RabbitMqSettings>();
        
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqSettings.Host, "/", h =>
                {
                    h.Username(rabbitMqSettings.UserName);
                    h.Password(rabbitMqSettings.Password);
                });

                cfg.Publish<BaseIntegrationEvent>(x => x.Exclude = true);

                cfg.Message<CustomerCreatedIntegrationEvent>(x => x.SetEntityName(rabbitMqSettings.DefaultExchangeName));
                cfg.Publish<CustomerCreatedIntegrationEvent>(x => x.ExchangeType = RabbitMQ.Client.ExchangeType.Direct);

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
