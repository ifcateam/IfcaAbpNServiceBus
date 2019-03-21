using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;

namespace IFCAnServiceBusMdl.DomainEvent.EventBus
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(ILocalEventBus), typeof(LearningLocalEventBus))]
    public class LearningLocalEventBus: ILocalEventBus
    {
        public LearningLocalEventBus()
        {
        }

        public Task PublishAsync<TEvent>(TEvent eventData) where TEvent : class
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync(Type eventType, object eventData)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe<TEvent>(Func<TEvent, Task> action) where TEvent : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe<TEvent, THandler>() where TEvent : class where THandler : IEventHandler, new()
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(Type eventType, IEventHandler handler)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe<TEvent>(IEventHandlerFactory factory) where TEvent : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(Type eventType, IEventHandlerFactory factory)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<TEvent>(Func<TEvent, Task> action) where TEvent : class
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<TEvent>(ILocalEventHandler<TEvent> handler) where TEvent : class
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(Type eventType, IEventHandler handler)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<TEvent>(IEventHandlerFactory factory) where TEvent : class
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(Type eventType, IEventHandlerFactory factory)
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeAll<TEvent>() where TEvent : class
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeAll(Type eventType)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe<TEvent>(ILocalEventHandler<TEvent> handler) where TEvent : class
        {
            throw new NotImplementedException();
        }
    }
}
