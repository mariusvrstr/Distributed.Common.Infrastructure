namespace Distributed.Common.Infrastructure.Domain.Events;

public static class DomainEventPublisher
{
    private static IDomainEventDispatcher? _dispatcher;
    public static void SetInstance(IDomainEventDispatcher instance)
    {
        _dispatcher = instance;
    }
    public static void Publish<T>(T @event) where T : IDomainEvent
    {
        if (_dispatcher == null)
        {
            throw new Exception("The IDomainEventDispatcher has not been set.");
        }
        _dispatcher.Publish(@event);
    }

    public static TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : IDomainRequest
    {
        if (_dispatcher == null)
        {
            throw new Exception("The IDomainEventDispatcher has not been set.");
        }
        return _dispatcher.Request<TRequest, TResponse>(request);
    }
    public static void Cleanup()
    {
        _dispatcher = null;
    }
}