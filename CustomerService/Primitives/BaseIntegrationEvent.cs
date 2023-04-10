namespace CustomerService.Primitives;

public class BaseIntegrationEvent
{    
    public BaseIntegrationEvent(Guid id, DateTime createdDate)
    {
        Id = id;
        CreatedDate = createdDate;
    }

    public BaseIntegrationEvent()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
    }

    public Guid Id { get; private init; }

    public DateTime CreatedDate { get; private init; }
}