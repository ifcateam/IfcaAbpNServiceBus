using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;
using NServiceBus.Persistence.Sql;

namespace IFCAnServiceBusMdl.OptionsHelper
{
    public class TransPortAndPersInitOptions : OptionsInitResponsibility
    {
        public TransPortAndPersInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        public override void Handle(
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            _endpointConfiguration
                .UsePersistence<InMemoryPersistence, StorageType.Subscriptions
                >();


            if (ifcAnServiceBusOptions.TransportType == ENUM_TRANSPORT.Rabbitmq)
            {


                var transport = _endpointConfiguration
                    .UseTransport<RabbitMQTransport>();

                transport.ConnectionString("host=192.168.137.51;" +
                                           "username=admin;" +
                                           "password=admin");
                transport.UseConventionalRoutingTopology();

            }

        }
    }
}
