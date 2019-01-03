using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using IFCAnServiceBusMdl.EndPoint;
using NServiceBus;
using Volo.Abp.DependencyInjection;

namespace TestDI
{
//    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IIFCAEndpoint))]
    public class CFCAEndpoint : IIFCAEndpoint
    {
        public CFCAEndpoint()
        {
            Debug.Print("ok");
        }

        public Task Send(object message, SendOptions options)
        {
            throw new NotImplementedException();
        }

        public Task Send<T>(Action<T> messageConstructor, SendOptions options)
        {
            throw new NotImplementedException();
        }

        public Task Publish(object message, PublishOptions options)
        {
            throw new NotImplementedException();
        }

        public Task Publish<T>(Action<T> messageConstructor, PublishOptions publishOptions)
        {
            throw new NotImplementedException();
        }

        public Task Subscribe(Type eventType, SubscribeOptions options)
        {
            throw new NotImplementedException();
        }

        public Task Unsubscribe(Type eventType, UnsubscribeOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
