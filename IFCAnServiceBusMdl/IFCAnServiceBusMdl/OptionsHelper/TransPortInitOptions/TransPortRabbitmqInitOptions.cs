﻿using NServiceBus;

namespace IFCAnServiceBusMdl.OptionsHelper.TransPortInitOptions
{
    public class TransPortRabbitmqInitOptions : TransPortInitOptions
    {
        public TransPortRabbitmqInitOptions(
            EndpointConfiguration endpointConfiguration) : base(
            endpointConfiguration)
        {
        }


        protected override void TransPortInit(IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            _endpointConfiguration
                .UsePersistence<InMemoryPersistence, StorageType.Subscriptions
                >();

            var transport = _endpointConfiguration
                .UseTransport<RabbitMQTransport>();

            transport.ConnectionString("host=192.168.137.51;" +
                                       "username=admin;" +
                                       "password=admin");
            transport.UseConventionalRoutingTopology();
        }
    }
}
