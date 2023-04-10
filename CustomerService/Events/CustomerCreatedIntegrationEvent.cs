using System.Text.Json.Serialization;

namespace MassTransit.Contracts;

[ConfigureConsumeTopology(false)]
public class CustomerCreatedIntegrationEvent
{
    [JsonInclude]
    public string Email { get; private set; } = string.Empty;

    [JsonConstructor]
    public CustomerCreatedIntegrationEvent(string email)
    {
        Email = email;
    }

    public static CustomerCreatedIntegrationEvent CreateCustomer(string email)
    {
        return new CustomerCreatedIntegrationEvent(email);
    }
}