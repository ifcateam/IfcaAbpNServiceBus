using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace UsersDomain
{
    public class AddUserEventData : IEvent
    {
        public string DataValue { get; set; }
    }
}
