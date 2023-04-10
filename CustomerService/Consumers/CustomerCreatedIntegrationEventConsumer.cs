using MassTransit;
using MassTransit.Contracts;
using System.Text.Json;

namespace CustomerService.Consumers;

public class CustomerCreatedIntegrationEventConsumer : IConsumer<CustomerCreatedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<CustomerCreatedIntegrationEvent> context)
    {
        var jsonMessage = JsonSerializer.Serialize(context.Message);
        Console.WriteLine($"----- NEW CUSTOMER REGISTERED: --{jsonMessage}------");
    }
}
