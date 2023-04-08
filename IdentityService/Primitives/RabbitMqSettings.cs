namespace IdentityService.Primitives;

public class RabbitMqSettings
{
    public const string SectionName = "RabbitMqSettings";

    public string Host { get; init; } = string.Empty;

    public string UserName { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public string DefaultExchangeName { get; init; } = string.Empty;
}
