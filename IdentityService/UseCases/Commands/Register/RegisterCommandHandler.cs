namespace IdentityService.UseCases.Commands.Register;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterCommandResponse>
{
    public Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new RegisterCommandResponse());
    }
}
