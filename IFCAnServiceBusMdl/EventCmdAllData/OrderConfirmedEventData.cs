using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace EventCmdAllData
{
    public class OrderConfirmedEventData : IEvent
    {
        public string OrderId { get; set; }
    }
}
