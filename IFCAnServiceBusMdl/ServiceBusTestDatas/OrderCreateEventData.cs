using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace ServiceBusTestDatas
{
    public class OrderCreateEventData : IEvent
    {
        public string OrderId { get; set; }
        public string Name { get; set; }
    }
}
