namespace Distributed.Common.Infrastructure.Domain.Events;

public interface IDomainEventDispatcher
{
    void Publish<T>(T @event) where T : IDomainEvent;
    TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : IDomainRequest;
}