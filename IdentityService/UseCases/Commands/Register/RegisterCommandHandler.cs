using MassTransit;
using MassTransit.Contracts;

namespace IdentityService.UseCases.Commands.Register;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterCommandResponse>
{
    private readonly IPublishEndpoint _publishEnpoint;

    public RegisterCommandHandler(IPublishEndpoint publishEnpoint)
    {
        _publishEnpoint = publishEnpoint;
    }

    public Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        _publishEnpoint.Publish(CustomerCreatedIntegrationEvent.CreateCustomer(request.Email));
        return Task.FromResult(new RegisterCommandResponse());
    }
}
