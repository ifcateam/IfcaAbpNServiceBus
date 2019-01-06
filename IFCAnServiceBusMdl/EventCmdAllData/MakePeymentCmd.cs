using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace EventCmdAllData
{
    public class MakePeymentCmd :ICommand
    {
        public string OrderId { get; set; }
    }
}
