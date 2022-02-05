namespace Distributed.Common.Infrastructure.Domain.Events;

public interface IDomainRequestHandler<TRequest, TResponse> where TRequest : IDomainRequest
{
    TResponse Handle(TRequest request);
}