using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NServiceBus;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace IFCAnServiceBusMdl.EndPoint
{
    public class IFCAEndpoint : IIFCAEndpoint
    {
        private readonly IEndpointInstance _endpointInstance;
        private readonly IFCAnServiceBusOptions _ifcAnServiceBusOptions;

        public IFCAEndpoint(IOptions<IFCAnServiceBusOptions> options)
        {
            _ifcAnServiceBusOptions = options.Value;

            var endpointConfiguration =
                new EndpointConfiguration(_ifcAnServiceBusOptions
                    .CurrentServiceName);


            if (_ifcAnServiceBusOptions.Container != null)
            {
                endpointConfiguration.UseContainer<AutofacBuilder>(
                    customizations: c =>
                    {
                        c.ExistingLifetimeScope(
                            _ifcAnServiceBusOptions.Container);
                    });
            }


            var transport =
                endpointConfiguration.UseTransport<LearningTransport>();

//            var routing = transport.Routing();
//            routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

            var endpointInstance =
                AsyncHelper.RunSync(() => Endpoint.Start(endpointConfiguration));

            _endpointInstance = endpointInstance;

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

        public Task Stop()
        {
            return _endpointInstance.Stop();
        }
    }
}
