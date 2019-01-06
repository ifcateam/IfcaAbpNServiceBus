using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace EventCmdAllData
{
    public class AddSeatesToWaitListCmd : ICommand
    {
        public string OrderId { get; set; }
        
    }
}
