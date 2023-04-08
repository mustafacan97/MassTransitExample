namespace IdentityService.Primitives;

public class BaseIntegrationEvent
{
    public Guid Id { get; init; }

	public BaseIntegrationEvent(Guid id)
	{
		Id = id;
	}

	public BaseIntegrationEvent()
	{
		Id = Guid.NewGuid();
	}
}
