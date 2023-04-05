using MediatR;

namespace IdentityService.UseCases.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}