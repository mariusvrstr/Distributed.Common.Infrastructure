using Distributed.Common.Infrastructure.Domain.Events;
using Microsoft.AspNetCore.Http;

namespace Distributed.Common.Infrastructure.Domain;

public class DomainEventDispatcherInstantiationMiddleware
{
    private readonly RequestDelegate _next;

    public DomainEventDispatcherInstantiationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IDomainEventDispatcher domainEventDispatcher)
    {
        // Doing a SetInstance here for a static class when this gets executed in parallel across multiple threads is
        // a problem.
        DomainEventPublisher.SetInstance(domainEventDispatcher);

        await _next(context);

        DomainEventPublisher.Cleanup();
    }
}