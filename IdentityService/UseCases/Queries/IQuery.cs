using MediatR;

namespace IdentityService.UseCases.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}