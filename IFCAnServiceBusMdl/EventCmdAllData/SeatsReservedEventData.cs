using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace EventCmdAllData
{
    public class SeatsReservedEventData : IEvent
    {
        public string OrderId { get; set; }
        public string SeatsNum { get; set; }
        public string ReservationId { get; set; }
    }
}
