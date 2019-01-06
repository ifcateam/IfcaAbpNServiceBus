using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace EventCmdAllData
{
    public class OrderCreateEventData : IEvent
    {
        public string OrderId { get; set; }
        public string Descript { get; set; }
        public string OrderCreateUserName { get; set; }
    }
}
