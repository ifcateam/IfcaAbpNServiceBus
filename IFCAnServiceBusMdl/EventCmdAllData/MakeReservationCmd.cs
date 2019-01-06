using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace EventCmdAllData
{
    public class MakeReservationCmd : ICommand
    {
        public string OrderId { get; set; }
    }
}
