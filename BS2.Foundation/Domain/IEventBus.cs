using System;
using System.Threading.Tasks;

namespace BS2.Foundation.Domain
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent eventData)
            where TEvent : class;

        Task PublishAsync(Type eventType, object eventData);

        IDisposable Subscribe<TEvent, THandler>()
            where TEvent : class
            where THandler : IEventHandler, new();

        IDisposable Subscribe(Type eventType, IEventHandler handler);
    }
}