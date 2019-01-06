using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace EventCmdAllData
{
    public class AddSeatsToWaitList : ICommand
    {
        public string OrderID { get; set; }
        public string SeatsNum { get; set; }
    }
}
