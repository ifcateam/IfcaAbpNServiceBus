using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using IFCAnServiceBusMdl.OptionsHelper;
using Microsoft.Extensions.Options;
using NServiceBus;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace IFCAnServiceBusMdl.EndPoint
{
    public class IFCAEndpoint : IIFCAEndpoint, IDisposable
    {
        private IEndpointInstance _endpointInstance;
        private readonly EndpointConfiguration _endpointConfiguration;
        private readonly IFCAnServiceBusOptions _ifcAnServiceBusOptions;

        public IFCAEndpoint(IOptions<IFCAnServiceBusOptions> options)
        {
            _ifcAnServiceBusOptions = options.Value;

            var endpointConfiguration =
                new EndpointConfiguration(_ifcAnServiceBusOptions
                    .CurrentServiceName);

            var initOptions = new BasicInitOptions(endpointConfiguration);
            initOptions.Handle(_ifcAnServiceBusOptions);

            _endpointConfiguration = endpointConfiguration;
            _endpointInstance = null;

        }

        public Task Send(object message, SendOptions options)
        {
            return _endpointInstance.Send(message, options);
        }

        public Task Send<T>(Action<T> messageConstructor, SendOptions options)
        {
            return _endpointInstance.Send(messageConstructor, options);
        }

        public Task Publish(object message, PublishOptions options)
        {
            return _endpointInstance.Publish(message, options);
        }

        public Task Publish<T>(Action<T> messageConstructor,
            PublishOptions publishOptions)
        {
            return _endpointInstance.Publish<T>(messageConstructor,
                publishOptions);
        }

        public Task Subscribe(Type eventType, SubscribeOptions options)
        {
            return _endpointInstance.Subscribe(eventType, options);
        }

        public Task Unsubscribe(Type eventType, UnsubscribeOptions options)
        {
            return _endpointInstance.Unsubscribe(eventType, options);
        }

        public async Task InitInstance()
        {
            if (_endpointInstance == null)
            {
                _endpointInstance = await Endpoint.Start(_endpointConfiguration);
            }

        }

        public Task Stop()
        {
            if (_endpointInstance != null)
            {
                return _endpointInstance.Stop();
            }            
            return Task.CompletedTask;
        }

        ~IFCAEndpoint()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            Stop();

        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
