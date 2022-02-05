namespace Distributed.Common.Infrastructure.Domain.Events;

public interface IDomainEventHandler<T> where T : IDomainEvent
{
    void Handle(T @event);
}