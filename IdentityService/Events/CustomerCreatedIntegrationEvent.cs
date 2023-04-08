using IdentityService.Primitives;

namespace IdentityService.Events;

public class CustomerCreatedIntegrationEvent : BaseIntegrationEvent
{
    public string Email { get; private set; } = string.Empty;

	private CustomerCreatedIntegrationEvent(string email)
	{
		Email = email;
	}

	public static CustomerCreatedIntegrationEvent CreateCustomer(string email)
	{
		return new CustomerCreatedIntegrationEvent(email);
	}
}
