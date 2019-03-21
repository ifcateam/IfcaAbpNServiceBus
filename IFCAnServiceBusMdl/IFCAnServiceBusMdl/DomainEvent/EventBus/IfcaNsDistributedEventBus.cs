using System;
using System.Threading.Tasks;
using IFCAnServiceBusMdl.EndPoint;
using NServiceBus;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;

namespace IFCAnServiceBusMdl.DomainEvent.EventBus
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IDistributedEventBus), typeof(IfcaNsDistributedEventBus))]
    public class IfcaNsDistributedEventBus : IDistributedEventBus,ISingletonDependency
    {
        private readonly IIFCAEndpoint _ifcaEndpoint;
        public IfcaNsDistributedEventBus(IIFCAEndpoint ifcaEndpoint)
        {
            _ifcaEndpoint = ifcaEndpoint;
        }

        public Task PublishAsync<TEvent>(TEvent eventData) where TEvent : class
        {
            return PublishAsync(typeof(TEvent), eventData);
        }

        public async Task PublishAsync(Type eventType, object eventData)
        {
            await _ifcaEndpoint.Publish(eventData);
        }

        public IDisposable Subscribe<TEvent>(Func<TEvent, Task> action) where TEvent : class
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public IDisposable Subscribe<TEvent, THandler>() where TEvent : class where THandler : IEventHandler, new()
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public IDisposable Subscribe(Type eventType, IEventHandler handler)
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public IDisposable Subscribe<TEvent>(IEventHandlerFactory factory) where TEvent : class
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public IDisposable Subscribe(Type eventType, IEventHandlerFactory factory)
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public void Unsubscribe<TEvent>(Func<TEvent, Task> action) where TEvent : class
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public void Unsubscribe<TEvent>(ILocalEventHandler<TEvent> handler) where TEvent : class
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public void Unsubscribe(Type eventType, IEventHandler handler)
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public void Unsubscribe<TEvent>(IEventHandlerFactory factory) where TEvent : class
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public void Unsubscribe(Type eventType, IEventHandlerFactory factory)
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public void UnsubscribeAll<TEvent>() where TEvent : class
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeAll(Type eventType)
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }

        public IDisposable Subscribe<TEvent>(IDistributedEventHandler<TEvent> handler) where TEvent : class
        {
            throw new UserFriendlyException(
                "In Scene of Distribution there is not Action of SubScribe，" +
                "because NServiceBus automatic Create it from all of assembling when initialling");
        }
    }
}
