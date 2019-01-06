using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace EventCmdAllData
{
    public class PaymentAcceptedEventData : IEvent
    {
        public string OrderId { get; set; }
        public string PayMentId { get; set; }
        public string PayAmount { get; set; }
    }
}
